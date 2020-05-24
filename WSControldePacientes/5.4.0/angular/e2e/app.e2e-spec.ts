import { WSControldePacientesApiTemplatePage } from './app.po';

describe('WSControldePacientesApi App', function() {
  let page: WSControldePacientesApiTemplatePage;

  beforeEach(() => {
    page = new WSControldePacientesApiTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
