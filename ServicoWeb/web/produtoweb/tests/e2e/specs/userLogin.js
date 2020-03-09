describe('User login', () => {

    it('Login user test', () => {
        cy.get('.back').click();
        cy.get('#terminarsessao').click();
        cy.get('#email').type('hugovinhal98@gmail.com');
        cy.get('#pass').type('123');
        cy.get('button').click();
        cy.get('.encomendaUser').click();

    });

    it('Lista de encomendas maior quantidade', () => {
        cy.contains('.maiorQuantidade', 'Produtos maior quantidade encomendados');
       
        cy.get('.maiorQuantidade').click();
        
        
    });
    it('Lista de encomendas geral', () => {
        
        cy.contains('.produtosGeral', 'Produtos');
        cy.get('.produtosGeral').click();

       
    });
    it('Lista de encomendas maior numero de encomendas test', () => {  
        cy.contains('.maiorNEncomendas', 'Produtos com mais encomendas');
       
        cy.get('.maiorNEncomendas').click();
        
    });
    it('Lista de encomendas menor tempo de producao test', () => {  
        cy.contains('.menorTempo', 'Produtos com menor tempo de produção');
       
        cy.get('.menorTempo').click();  
    });
    it('Consultar encomenda selecionada test', () => {  
        cy.get('#apresentarEncomendasUser').click();
        cy.get('[type="radio"]').first().check();
        cy.get("#consultarEncomendaSelecionadaUser").click(); 
    });
});
