import { expect } from 'chai'
import { shallowMount } from '@vue/test-utils'
import TipoMaquina from '@/components/TipoMaquina.vue'


describe('TipoMaquina.vue', () => {

  it('button render operacoes by descricao tipo de maquina text', () => {
    const wrapper = shallowMount(TipoMaquina);
    expect(
      wrapper
        .find('#GetOperacoesByDescricaoTipoMaquina')
        .text()
    ).equal('Consultar operações de tipo de maquina');
  });

/*   it('button render operacoes de tipo de maquina text', () => {
    const wrapper = shallowMount(TipoMaquina);
    expect(
      wrapper
        .find('#AlterarOperacoesTipoMaquina')
        .text()
    ).equal('Alterar operações de tipo de maquina');
  });

  it('button render get tipo de maquina by descricao text', () => {
    const wrapper = shallowMount(TipoMaquina);
    expect(
      wrapper
        .find('#getTipoMaquinaByDescricao')
        .text()
    ).equal('Obter Tipo Máquina');
  });

  it('button render criar tipo maquina text', () => {
    const wrapper = shallowMount(TipoMaquina);
    expect(
      wrapper
        .find('#postTipoMaquina')
        .text()
    ).equal('Criar Tipo Máquina');
  });

  it('button clears all data text', () => {
    const wrapper = shallowMount(TipoMaquina);
    expect(
      wrapper
        .find('#clearData')
        .text()
    ).equal('Limpar dados');
  }); */

});
