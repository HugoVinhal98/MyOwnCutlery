describe('Cutlery', () => {

    it('Checks apresentarEncomendas button', () => {
        cy.visit('localhost:8080/#/encomendaAdmin')
        cy.contains('Encomendas').click()
        cy.get('[type="radio"]').first().check();
    });

    it('Checks consultarEncomendaSelecionada button', () => {
        cy.contains('#alterarEncomendaSelecionada', 'Alterar Encomenda Selecionada')
    });

    it('Checks consultarEncomendaSelecionada button', () => {
        cy.contains('#cancelarEncomendaSelecionada', 'Cancelar Encomenda Selecionada')
    });

    it('Checks consultarEncomendaSelecionada button', () => {
        cy.contains('#consultarEncomendaSelecionada', 'Consultar Encomenda Selecionada')
    });

});