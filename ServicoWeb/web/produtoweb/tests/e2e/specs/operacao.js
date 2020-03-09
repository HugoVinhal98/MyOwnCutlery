
describe('Cutlery', () => {
  it('Checks Operacao title', () => {
    cy.visit('http://localhost:8080/#/operacao')
    cy.contains('h1', 'Master Data Fabrica')
  });
  it('Checks getOperacoes button', () => {
    cy.visit('http://localhost:8080/#/operacao')
    cy.contains('#getOperacoes', 'Obter Operações')
  });
  it('Checks getTipoOperacoes button', () => {
    cy.visit('http://localhost:8080/#/operacao')
    cy.contains('#getTipoOperacoes', 'Obter Tipos de Operação')
  });
  it('Checks postOperacao button', () => {
    cy.visit('http://localhost:8080/#/operacao')
    cy.contains('#postOperacao', 'Criar Operação')
  });
  it('Checks clearData button', () => {
    cy.visit('http://localhost:8080/#/operacao')
    cy.contains('#clearData', 'Limpar dados')
  });
});
