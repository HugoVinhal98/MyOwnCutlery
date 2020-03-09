import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import AlterarCliente from '@/components/AlterarCliente.vue'

describe('AlterarCliente.vue', () => {

    it('button render obter alterar cliente text', () => {
        const wrapper = shallowMount(AlterarCliente);
        expect(
            wrapper
                .find('#alterarCliente')
                .text()
        ).equal('Alterar informações pessoais');
    });

});