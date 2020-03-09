
describe('Cutlery', () => {
  it('Checks TipoMaquina title', () => {
    cy.visit('http://localhost:8080/#/tipoMaquina')
    cy.contains('h1', 'Master Data Fabrica')
  });
  it('Checks getOperacoesTipoMaquina button', () => {
    cy.visit('http://localhost:8080/#/tipoMaquina')
    cy.contains('#GetOperacoesByDescricaoTipoMaquina', 'Consultar operações de tipo de maquina')
  });
  it('Checks alterarOperacoesTipoMaquina button', () => {
    cy.visit('http://localhost:8080/#/tipoMaquina')
    cy.contains('#AlterarOperacoesTipoMaquina', 'Alterar operações de tipo de maquina')
  });
  it('Checks getTipoMaquinaByDescricao button', () => {
    cy.visit('http://localhost:8080/#/tipoMaquina')
    cy.contains('#getTipoMaquinaByDescricao', 'Obter Tipo Máquina')
  });
  it('Checks postTipoMaquina button', () => {
    cy.visit('http://localhost:8080/#/tipoMaquina')
    cy.contains('#postTipoMaquina', 'Criar Tipo Máquina')
  });
  it('Checks clearData button', () => {
    cy.visit('http://localhost:8080/#/tipoMaquina')
    cy.contains('#clearData', 'Limpar dados')
  });
});
