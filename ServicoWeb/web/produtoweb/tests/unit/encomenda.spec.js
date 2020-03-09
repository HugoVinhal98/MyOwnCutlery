import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import Encomenda from '@/components/Encomenda.vue'

describe('Encomenda.vue', () => {

    it('button render apresentar encomendas user text', () => {
        const wrapper = shallowMount(Encomenda);
        expect(
            wrapper
                .find('#apresentarEncomendasUser')
                .text()
        ).equal('Encomendas');
    });
 
     it('button render produtos maior quantidade encomendados user text', () => {
         const wrapper = shallowMount(Encomenda);
         expect(
             wrapper
                 .find('#produtosMaiorQuantidade')
                 .text()
         ).equal('Produtos maior quantidade encomendados');
     });

     it('button render apresentar todos produtos user text', () => {
        const wrapper = shallowMount(Encomenda);
        expect(
            wrapper
                .find('#apresentarTodosProdutos')
                .text()
        ).equal('Produtos');
    });

    it('button render proutos com mais encomendas user text', () => {
        const wrapper = shallowMount(Encomenda);
        expect(
            wrapper
                .find('#produtosMaisEncomendas')
                .text()
        ).equal('Produtos com mais encomendas');
    });

    it('button render produtos com menor tempo de producao user text', () => {
        const wrapper = shallowMount(Encomenda);
        expect(
            wrapper
                .find('#produtosMenorTempo')
                .text()
        ).equal('Produtos com menor tempo de produção');
    });

});