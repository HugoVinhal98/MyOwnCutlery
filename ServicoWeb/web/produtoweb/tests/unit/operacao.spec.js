import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import Operacao from '@/components/Operacao.vue'
import Login from '@/components/Login.vue'

describe('Operacao.vue', () => {

    it('renders h1 tag', () => {
        const wrapper = shallowMount(Operacao);
        expect(
            wrapper
                .find('h1')
                .text()
        ).equal('Master Data Fabrica');
    });

    it('button render operacoes text', () => {

        const wrapper2 = shallowMount(Login);
        wrapper2.find("[username]").setValue("admin")
        wrapper2.find("[email]").setValue("admin")
        wrapper2.find("button").trigger("click");

        const wrapper = shallowMount(Operacao);
        expect(
            wrapper
                .find('#getOperacoes')
                .text()
        ).equal('Obter Operações');
    });

    it('button render tipo operacoes text', () => {
        const wrapper = shallowMount(Operacao);
        expect(
            wrapper
                .find('#getTipoOperacoes')
                .text()
        ).equal('Obter Tipos de Operação');
    });

    it('button render criar operacao text', () => {
        const wrapper = shallowMount(Operacao);
        expect(
            wrapper
                .find('#postOperacao')
                .text()
        ).equal('Criar Operação');
    });

});

