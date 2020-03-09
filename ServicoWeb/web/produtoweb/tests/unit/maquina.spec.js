import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import Maquina from '@/components/Maquina.vue'


describe('Maquina.vue', () => {
  it('renders h1 tag', () => {
    const wrapper = shallowMount(Maquina);
    expect(
      wrapper
        .find('h1')
        .text()
    ).equal('Master Data Producao');
  });

  it('button render getMaquina text', () => {
    const wrapper = shallowMount(Maquina);
    expect(
      wrapper
        .find('#getMaquinas')
        .text()
    ).equal('Obter Máquinas');
  });

  it('button render maquina by descricao text', () => {
    const wrapper = shallowMount(Maquina);
    expect(
      wrapper
        .find('#getMaquinaByDescricao')
        .text()
    ).equal('Obter Máquina Por Descrição');
  });

  it('button render get maquinas tipo maquina text', () => {
    const wrapper = shallowMount(Maquina);
    expect(
      wrapper
        .find('#getMaquinasTipoMaquina')
        .text()
    ).equal('Obter Máquinas de um Tipo de Máquina');
  });

  it('button render post maquina text', () => {
    const wrapper = shallowMount(Maquina);
    expect(
      wrapper
        .find('#postMaquina')
        .text()
    ).equal('Criar Máquina');
  });

  it('button render put tipo maquina in maquina text', () => {
    const wrapper = shallowMount(Maquina);
    expect(
      wrapper
        .find('#putTipoMaquinaInMaquina')
        .text()
    ).equal('Alterar Tipo Máquina de Máquina');
  });

  it('button clears all data text', () => {
    const wrapper = shallowMount(Maquina);
    expect(
      wrapper
        .find('#clearData')
        .text()
    ).equal('Limpar dados');
  });

});
