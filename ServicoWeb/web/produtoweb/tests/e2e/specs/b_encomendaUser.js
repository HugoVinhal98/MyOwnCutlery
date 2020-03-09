describe('Cutlery', () => {
    it('Checks apresentarEncomendasUser button', () => {
        cy.visit('localhost:8080/#/encomenda')
        cy.contains('Encomendas').click()
    });
});