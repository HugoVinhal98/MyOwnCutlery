import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import Cliente from '@/components/Cliente.vue'

describe('Operacao.vue', () => {

    it('renders h1 tag', () => {
        const wrapper = shallowMount(Cliente);
        expect(
            wrapper
                .find('h1')
                .text()
        ).equal('Master Data Fabrica');
    });

    it('button render tipo operacoes text', () => {
        const wrapper = shallowMount(Cliente);
        expect(
            wrapper
                .find('#getClientes')
                .text()
        ).equal('Obter clientes');
    });

});