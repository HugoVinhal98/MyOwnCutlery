describe('Cutlery', () => {

  it('Checks LinhaProducao title', () => {
    cy.visit('http://localhost:8080/#/linhaproducao')
    cy.contains('h1', 'Master Data Fabrica')
  });

  it('Checks GetLinhasProducao button', () => {
    cy.visit('http://localhost:8080/#/linhaproducao');
    cy.contains('#getLinhasProducao', 'Obter Linhas de Produção');
  });

  it('Checks PostLinhaProducao button', () => {
    cy.visit('http://localhost:8080/#/linhaproducao')
    cy.contains('#postLinhaProducao', 'Criar Linha de Produção')
  });

  it('Checks PutLinhaProducaoMaquina button', () => {
    cy.visit('http://localhost:8080/#/linhaproducao')
    cy.contains('#putLinhaProducaoMaquina', 'Inserir máquinas na linha de produção')
  });

});