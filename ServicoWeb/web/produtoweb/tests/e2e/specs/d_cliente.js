describe('Cutlery', () => {

    it('Checks getClientes button', () => {
        cy.visit('http://localhost:8080/#/cliente')
        cy.contains('#getClientes', 'Obter clientes')
    });

    it('Checks alterarCliente button', () => {
        cy.visit('http://localhost:8080/#/alterarClienteAdmin')
        cy.contains('#alterarCliente', 'Alterar informações pessoais')
    });

});