import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import EncomendaAdmin from '@/components/EncomendaAdmin.vue'

describe('EncomendaAdmin.vue', () => {

    it('renders h1 tag', () => {
        const wrapper = shallowMount(EncomendaAdmin);
        expect(
            wrapper
                .find('h1')
                .text()
        ).equal('Master Data Fabrica');
    });

    it('button render criar operacao text', () => {
        const wrapper = shallowMount(EncomendaAdmin);
        expect(
            wrapper
                .find('#apresentarEncomendas')
                .text()
        ).equal('Encomendas');
    });

    it('button render criar operacao text', () => {
        const wrapper = shallowMount(EncomendaAdmin);
        expect(
            wrapper
                .find('#alterarEncomendaSelecionada')
                .text()
        ).equal('Alterar Encomenda Selecionada');
    });

    it('button render criar operacao text', () => {
        const wrapper = shallowMount(EncomendaAdmin);
        expect(
            wrapper
                .find('#cancelarEncomendaSelecionada')
                .text()
        ).equal('Cancelar Encomenda Selecionada');
    });

    it('button render criar operacao text', () => {
        const wrapper = shallowMount(EncomendaAdmin);
        expect(
            wrapper
                .find('#consultarEncomendaSelecionada')
                .text()
        ).equal('Consultar Encomenda Selecionada');
    });

});