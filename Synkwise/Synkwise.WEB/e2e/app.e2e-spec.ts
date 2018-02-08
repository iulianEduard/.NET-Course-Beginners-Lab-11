import { Synkwise.WEBPage } from './app.po';

describe('synkwise.web App', () => {
  let page: Synkwise.WEBPage;

  beforeEach(() => {
    page = new Synkwise.WEBPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
