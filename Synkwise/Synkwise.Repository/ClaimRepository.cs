using Microsoft.AspNetCore.Identity;
using Synkwise.Core.Exceptions.Claim;
using Synkwise.Repository.Helpers;
using Synkwise.Repository.Models.Account;
using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class ClaimRepository : IClaimRepository
    {
        #region Attributes

        private readonly UserManager<UserEntity> _userManager;

        #endregion Attributes


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="userManager"></param>
        public ClaimRepository(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Add claim
        /// </summary>
        /// <param name="email">User email address</param>
        /// <param name="claimType">Claim type</param>
        /// <param name="claimValue">Claim value</param>
        /// <returns>No error in case of success</returns>
        public async Task Add(string email, string claimType, string claimValue)
        {
            var user = await GetUser(email);
            var claimsDictionary = await GetClaims(user);

            if(claimsDictionary.ContainsKey(claimType))
            {
                var existingClaimValues = claimsDictionary[claimType];

                await RemoveClaim(user, claimType);

                var claim = new Claim(claimType, existingClaimValues + "," + claimValue);

                await AddClaim(user, claim);
            }
            else
            {
                var claim = new Claim(claimType, claimValue);

                await AddClaim(user, claim);
            }
        }

        /// <summary>
        /// Get claims for user
        /// </summary>
        /// <param name="email">User email address</param>
        /// <returns>A dictionary with claim types and values</returns>
        public async Task<Dictionary<string, string>> GetAllClaims(string email)
        {
            var user = await GetUser(email);
            return await GetClaims(user);
        }

        /// <summary>
        /// Get claim values
        /// </summary>
        /// <param name="email">User email address</param>
        /// <param name="claimType">Claim type</param>
        /// <returns>Claim value</returns>
        public async Task<string> GetClaimValueByType(string email, string claimType)
        {
            var user = await GetUser(email);
            var claimDictionary = await GetClaims(user);

            return claimDictionary[claimType];
        }

        /// <summary>
        /// Remove claim
        /// </summary>
        /// <param name="email">User email address</param>
        /// <param name="claimType">Claim to remove</param>
        /// <returns>No errors in case of success</returns>
        public async Task RemoveClaimType(string email, string claimType)
        {
            var user = await GetUser(email);
            await RemoveClaim(user, claimType);
        }

        public Task RemoveClaimValue(string email, string claimType, string claimValue)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

        #region Private Methods
        
        private async Task<UserEntity> GetUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        private async Task<Dictionary<string, string>> GetClaims(UserEntity user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var claimDictionary = new Dictionary<string, string>();

            foreach(var claim in claimDictionary)
            {
                if(!claimDictionary.ContainsKey(claim.Key))
                {
                    claimDictionary.Add(claim.Key, claim.Value);
                }
            }

            return claimDictionary;
        }

        private async Task RemoveClaim(UserEntity userEntity, string claimType)
        {
            var claim = new Claim(claimType, "");

            var result = await _userManager.RemoveClaimAsync(userEntity, claim);

            if(!result.Succeeded)
            {
                throw new ClaimInternalServerErrorException(result.Errors.ToExceptionMessage());
            }
        }

        public async Task AddClaim(UserEntity userEntity, Claim claim)
        {
            var result = await _userManager.AddClaimAsync(userEntity, claim);

            if(!result.Succeeded)
            {
                throw new ClaimInternalServerErrorException(result.Errors.ToExceptionMessage());
            }
        }

        #endregion Private Methods
    }
}
