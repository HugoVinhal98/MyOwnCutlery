// https://docs.cypress.io/api/introduction/api.html

describe('Cutlery', () => {
  it('Checks Produto title', () => {
    cy.visit('http://localhost:8080/#/produto')
    cy.contains('h1', 'Master Data Producao')
  });
  it('Checks getProdutos button', () => {
    cy.visit('http://localhost:8080/#/produto')
    cy.contains('#getProdutos', 'Obter Produtos')
  });
  it('Checks getProdutosByNome button', () => {
    cy.visit('http://localhost:8080/#/produto')
    cy.contains('#getProdutoByNome', 'Obter Produto Por Nome')
  });
  it('Checks getPlanoFabrico button', () => {
    cy.visit('http://localhost:8080/#/produto')
    cy.contains('#getPlanoFabrico', 'Obter Plano de Fabrico de Produto')
  });
  it('Checks postProduto button', () => {
    cy.visit('http://localhost:8080/#/produto')
    cy.contains('#postProduto', 'Criar Produto')
  });
  it('Checks clearData button', () => {
    cy.visit('http://localhost:8080/#/produto')
    cy.contains('#clearData', 'Limpar dados')
  });
});
