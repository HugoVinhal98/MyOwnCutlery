
describe('Cutlery', () => {
    it('Checks Maquina title', () => {
        cy.visit('http://localhost:8080/#/maquina')
        cy.contains('h1', 'Master Data Fabrica')
    });
    it('Checks getMaquinas button', () => {
        cy.visit('http://localhost:8080/#/maquina')
        cy.contains('#getMaquinas', 'Obter Máquinas')
    });
    ;
    it('Checks getMaquinaByDescricao button', () => {
        cy.visit('http://localhost:8080/#/maquina')
        cy.contains('#getMaquinaByDescricao', 'Obter Máquina Por Descrição')
    });
    it('Checks getMaquinasTipoMaquina button', () => {
        cy.visit('http://localhost:8080/#/maquina')
        cy.contains('#getMaquinasTipoMaquina', 'Obter Máquinas de um Tipo de Máquina')
    });
    it('Checks postMaquina button', () => {
        cy.visit('http://localhost:8080/#/maquina')
        cy.contains('#postMaquina', 'Criar Máquina')
    });
    it('Checks clearData button', () => {
        cy.visit('http://localhost:8080/#/maquina')
        cy.contains('#clearData', 'Limpar dados')
    });
});