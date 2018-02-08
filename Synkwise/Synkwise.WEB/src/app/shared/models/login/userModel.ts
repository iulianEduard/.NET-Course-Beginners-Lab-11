/**
 * Created by coprita on 11/19/2017.
 */
export class UserModel {
  constructor(firstName: string,
              lastName: string,
              email: string,
              password: string,
              user?: any,
              id?: number) {
  }
}

export class UserInfo {
  email: string;
  token: string;
  message: any;
  role: string;
  createdAt: string;
  expires_in: number;
}
