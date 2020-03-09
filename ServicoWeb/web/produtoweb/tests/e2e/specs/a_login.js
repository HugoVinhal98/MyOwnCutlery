describe('Cutlery', () => {

    it('Login test', () => {
        cy.visit('localhost:8080/#/login')
        cy.get('#email').type('admin');
        cy.get('#pass').type('admin');
        cy.get('button').click();
    });

});
