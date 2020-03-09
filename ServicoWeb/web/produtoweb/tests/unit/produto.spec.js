import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import Produto from '@/components/Produto.vue'


describe('Produto.vue', () => {
  it('renders h1 tag', () => {
    const wrapper = shallowMount(Produto);
    expect(
      wrapper
        .find('h1')
        .text()
    ).equal('Master Data Producao');
  });

  it('button render produtos text', () => {
    const wrapper = shallowMount(Produto);
    expect(
      wrapper
        .find('#getProdutos')
        .text()
    ).equal('Obter Produtos');
  });

  it('button render produto by nome text', () => {
    const wrapper = shallowMount(Produto);
    expect(
      wrapper
        .find('#getProdutoByNome')
        .text()
    ).equal('Obter Produto Por Nome');
  });

  it('button render plano de fabrico text', () => {
    const wrapper = shallowMount(Produto);
    expect(
      wrapper
        .find('#getPlanoFabrico')
        .text()
    ).equal('Obter Plano de Fabrico');
  });

  it('button render criar produto text', () => {
    const wrapper = shallowMount(Produto);
    expect(
      wrapper
        .find('#postProduto')
        .text()
    ).equal('Criar Produto');
  });

  it('button clears all data text', () => {
    const wrapper = shallowMount(Produto);
    expect(
      wrapper
        .find('#clearData')
        .text()
    ).equal('Limpar dados');
  });
});
