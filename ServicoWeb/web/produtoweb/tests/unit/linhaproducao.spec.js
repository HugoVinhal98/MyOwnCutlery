import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import LinhaProducao from '@/components/LinhaProducao.vue'

describe('LinhaProducao.vue', () => {
    it('renders h1 tag', () => {
        const wrapper = shallowMount(LinhaProducao);
        expect(
            wrapper
                .find('h1')
                .text()
        ).equal('Master Data Fabrica');
    });

    it('button render obter linha producao text', () => {
        const wrapper = shallowMount(LinhaProducao);
        expect(
            wrapper
                .find('#getLinhasProducao')
                .text()
        ).equal('Obter Linhas de Produção');
    });

    it('button render criar linha producao text', () => {
        const wrapper = shallowMount(LinhaProducao);
        expect(
            wrapper
                .find('#postLinhaProducao')
                .text()
        ).equal('Criar Linha de Produção');
    });

    it('button render inserir maquinas linha producao text', () => {
        const wrapper = shallowMount(LinhaProducao);
        expect(
            wrapper
                .find('#putLinhaProducaoMaquina')
                .text()
        ).equal('Inserir máquinas na linha de produção');
    });
});