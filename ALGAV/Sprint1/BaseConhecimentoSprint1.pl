% F�BRICA
 
% Linhas
 
linhas([lA]).
 
 
% Maquinas
 
 
maquinas([ma]).
 
 
 
% Ferramentas
 
 
ferramentas([fa,fa,fc]).
 
 
% Maquinas que constituem as Linhas
 
tipos_maq_linha(lA,[ma]).
% ...
 
 
% Opera��es
 
tipo_operacoes([opt1,opt2,opt3]).
 
% operacoes/1 deve ser criado dinamicamente
 operacoes([op1,op2,op3,op4,op5]).
 
%operacoes_atrib_maq depois deve ser criado dinamicamente
 operacoes_atrib_maq(ma,[op1,op2,op3,op4,op5]).
 
% classif_operacoes/2 deve ser criado dinamicamente %%atomic_concat(op,NumOp,Resultado)
 classif_operacoes(op1,opt1).
classif_operacoes(op2,opt2).
classif_operacoes(op3,opt1).
classif_operacoes(op4,opt2).
classif_operacoes(op5,opt3).
 
 
 
/* classif_operacoes(op11,opt3).
classif_operacoes(op12,opt2).
classif_operacoes(op13,opt2).
classif_operacoes(op14,opt3).  */
 
 
 
% ...
 
 
% Afeta��o de tipos de opera��es a tipos de m�quinas
% com Framentas, tempos de setup e tempos de execucao)
 
operacao_maquina(opt1,ma,fa,5,60).
operacao_maquina(opt2,ma,fb,6,30).
operacao_maquina(opt3,ma,fc,8,40).
%...
 
 
% PRODUTOS
 
produtos([pA,pB,pC]).
 
operacoes_produto(pA,[opt1]).
operacoes_produto(pB,[opt2]).
operacoes_produto(pC,[opt3]).
 
 
 
% ENCOMENDAS
 
%Clientes
 
clientes([clA,clB]).
 
 
% prioridades dos clientes
 
prioridade_cliente(clA,1).
prioridade_cliente(clB,2).
% ...
 
% Encomendas do cliente,
% termos e(<produto>,<n.unidades>,<tempo_conclusao>)
 
encomenda(clA,[e(pA,1,100),e(pB,1,100)]).
encomenda(clB,[e(pA,1,110),e(pB,1,150),e(pC,1,300)]).
% ...
 
:- dynamic operacoes_atrib_maq/2.
:- dynamic classif_operacoes/2.
:- dynamic op_prod_client/9.
:- dynamic operacoes/1.
 
 
cria_op_enc:-retractall(operacoes(_)),
retractall(operacoes_atrib_maq(_,_)),retractall(classif_operacoes(_,_)),
retractall(op_prod_client(_,_,_,_,_,_,_,_,_)),
        findall(t(Cliente,Prod,Qt,TConc),
        (encomenda(Cliente,LE),member(e(Prod,Qt,TConc),LE)),
        LT),cria_ops(LT,0),
findall(Op,classif_operacoes(Op,_),LOp),asserta(operacoes(LOp)),
maquinas(LM),
 findall(_,
        (member(M,LM),
         findall(Opx,op_prod_client(Opx,M,_,_,_,_,_,_,_),LOpx),
         assertz(operacoes_atrib_maq(M,LOpx))),_).
 
cria_ops([],_).
cria_ops([t(Cliente,Prod,Qt,TConc)|LT],N):-
            operacoes_produto(Prod,LOpt),
    cria_ops_prod_cliente(LOpt,Prod,Cliente,Qt,TConc,N,N1),
            cria_ops(LT,N1).
 
cria_ops_prod_cliente([],_,_,_,_,Nf,Nf).
cria_ops_prod_cliente([Opt|LOpt],Client,Prod,Qt,TConc,N,Nf):-
        cria_ops_prod_cliente2(Opt,Prod,Client,Qt,TConc,N,Ni),
    cria_ops_prod_cliente(LOpt,Client,Prod,Qt,TConc,Ni,Nf).
 
 
cria_ops_prod_cliente2(_,_,_,0,_,Ni,Ni):-!.
cria_ops_prod_cliente2(Opt,Prod,Client,Qt,TConc,N,Ni2):-
            Ni is N+1,
            atomic_concat(op,Ni,Op),
            assertz(classif_operacoes(Op,Opt)),
            operacao_maquina(Opt,M,F,TSet,TEx),
    assertz(op_prod_client(Op,M,F,Prod,Client,Qt,TConc,TSet,TEx)),
    Qt2 is Qt -1,
    cria_ops_prod_cliente2(Opt,Prod,Client,Qt2,TConc,Ni,Ni2).
 
 
 
 
:-cria_op_enc. 
 
 
% Separar posteriormente em varios ficheiros
 
% d) Permuta vai realizar um numero de solucoes igual ao fatorial do numero de elementos da lista
% permuta/2 gera permuta��es de listas
permuta([ ],[ ]).
permuta(L,[X|L1]):-apaga1(X,L,Li),permuta(Li,L1).
 
apaga1(X,[X|L],L).
apaga1(X,[Y|L],[Y|L1]):-apaga1(X,L,L1).
 
 
% permuta_tempo/3 faz uma permuta��o das opera��es atribu�das a uma maquina e calcula tempo de ocupa��o incluindo trocas de Framentas
/* permuta_tempo(M,LP,Tempo) que se for
chamado com o 1º argumento instanciado com o nome da máquina
coloca em LP um sequenciamento (permutação) das operações e o
respetivo tempo de ocupação (Tempo) da máquina, considerando os
tempos para troca de Framentas */
 
permuta_tempo(M,LP,Tempo):- operacoes_atrib_maq(M,L),
permuta(L,LP),soma_tempos(semfer,M,LP,Tempo).
 
 
soma_tempos(_,_,[],0).
soma_tempos(Fer,M,[Op|LOp],Tempo):- classif_operacoes(Op,Opt),
    operacao_maquina(Opt,M,Fer1,TSet,TEx),
    soma_tempos(Fer1,M,LOp,Tempo1),
    ((Fer1==Fer,!,Tempo is TEx+Tempo1);
            Tempo is TSet+TEx+Tempo1).
 
 
 
% melhor escalonamento com findall, gera todas as solucoes e escolhe melhor
/*melhor_escalonamento(M,Lm,Tm) que se for
chamado com o 1º argumento instanciado com o nome da máquina
coloca em Lm a sequência (permutação) das operações que corresponda
ao menor tempo de ocupação (Tm) da máquina.  */
 
melhor_escalonamento(M,Lm,Tm):-
                get_time(Ti),
                findall(p(LP,Tempo),
                permuta_tempo(M,LP,Tempo), LL),
                melhor_permuta(LL,Lm,Tm),
                get_time(Tf),Tcomp is Tf-Ti,
                write('GERADO EM '),write(Tcomp),
                write(' SEGUNDOS'),nl.
 
:- dynamic melhor_sol_to/2.
 
melhor_escalonamento1(M,Lm,Tm):-
    get_time(Ti),
    (melhor_escalonamento11(M);true),retract(melhor_sol_to(Lm,Tm)),
    get_time(Tf),Tcomp is Tf-Ti,
    write('GERADO EM '),write(Tcomp),
    write(' SEGUNDOS'),nl.
 
melhor_escalonamento11(M):- asserta(melhor_sol_to(_,10000)),!,
    permuta_tempo(M,LP,Tempo),
    atualiza(LP,Tempo),
    fail.
 
atualiza(LP,T):-melhor_sol_to(_,Tm),
    T<Tm,retract(melhor_sol_to(_,_)),asserta(melhor_sol_to(LP,T)),!.
 
melhor_permuta([p(LP,Tempo)],LP,Tempo):-!.
melhor_permuta([p(LP,Tempo)|LL],LPm,Tm):- melhor_permuta(LL,LP1,T1),((Tempo<T1,!,Tm is Tempo,LPm=LP);(Tm is T1,LPm=LP1)).
 
 
 
% Heurística para Tempo de Ocupação
heuristicaTO(M,Lm,Tm):-
                get_time(Ti),  
                operacoes_atrib_maq(M,ListOp), % guarda a lista de operacoes da maquina
                bubblesort(ListOp,Lm),
                soma_tempo(Lm,Tm),
                get_time(Tf),Tcomp is Tf-Ti,
                write('GERADO EM '),write(Tcomp),
                write(' SEGUNDOS'),nl.
 
bubblesort(L1,L2) :- swap(L1,List) , ! , bubblesort(List,L2).
bubblesort(L2,L2) :- !.
 
%organiza a lista de operações por feramentas
swap([X,Y|List],[Y,X|List]) :-
    classif_operacoes(X,Opt1), % guarda o tipo de operação de X
    operacao_maquina(Opt1,_,Fr,_,_),  % guarda a ferramenta usada pelo tipo de operacao
    classif_operacoes(Y,Opt2), % guarda o tipo de operação de Y
    operacao_maquina(Opt2,_,Fr2,_,_), % guarda a ferramenta usada pelo tipo de operacao
    Fr @< Fr2.
   
swap([Z|List],[Z|List1]) :- swap(List,List1).
 
%soma dos tempos consoante a troca de ferreamenta ou não
soma_tempo([Op|Lm],Tm):-
    classif_operacoes(Op,Opt),  % guarda o tipo de operação da operação
    operacao_maquina(Opt,_,Fr,TSet,TEx), % guarda os dados desse tipo de operação
    soma_tempo2(Fr,Lm,Tm1),
    Tm is TSet+TEx+Tm1.
 
soma_tempo2(Fr,[],0).
soma_tempo2(Fr,[Op|Lm],Tm) :-
        classif_operacoes(Op,Opt), % guarda o tipo de operação de operação
        operacao_maquina(Opt,_,Fr2,TSet,TEx), % guarda os dados desse tipo de operação
        soma_tempo2(Fr2,Lm,Tm1),
        ((Fr2 = Fr,!,Tm is TEx+Tm1); % se for igual adiciona o tempo execucao
        Tm is TSet+TEx+Tm1). % se for diferente adiciona tempo execucao e setup
		
% Segunda Heuristica 
heuristica_MSTA(C,LO,TAtraso):-
		get_time(Ti),   % Tempo que se inicia a operação
		findall(X,op_prod_client(X,_,_,C,_,_,_,_,_),LAux), 			% vai buscar todas as operações relativas a uma encomenda de um determindado cliente 
		bubblesort1(LAux,LO),			% Ordena as operações dando prioridade ao menor tempo de conclusão, EDD.
		tempo_Atraso(LO,TOcupado,TPrazo),
		TAtraso is TPrazo - TOcupado,
		get_time(Tf),To is Tf-Ti,     % Tempo final - tempo inicial para saber quanto tempo demororu a realizar a operação
		write('GERADO EM '),write(To),
		write(' SEGUNDOS'),nl.	% Texto com a informação de quanto tempo demorou a realizar a operacao
		
		
bubblesort1(InputList,SortList) :-
        swap1(InputList,List) , ! ,
        bubblesort1(List,SortList).
bubblesort1(SortList,SortList).

% altera conforme o tempo de conclusao 
swap1([X,Y|List],[Y,X|List]) :- 
	op_prod_client(X,_,_,_,_,_,TCa,_,_),
	op_prod_client(Y,_,_,_,_,_,TCb,_,_),
	TCa > TCb.
swap1([Z|List],[Z|List1]) :- 
	swap1(List,List1).


tempo_Atraso(LOp,TOcupado,TCMaior):- 
	tempo_Atraso2(semferr,LOp,TOcupado),
	tempo_TCMaior(semferr, LOp, TCMaior).
	

tempo_Atraso2(Fr,[],0):-!.
tempo_Atraso2(Fr,[Op|LOp],TOcupado):-
	op_prod_client(Op,_,Fr2,_,_,_,TPrazo,TSetup,TExec),
	tempo_Atraso2(Fr2,LOp,TOcupado1),
	((Fr2 = Fr,!,TOcupado is TExec+TOcupado1);
	TOcupado is TSetup+TExec+TOcupado1).

% Tempo de conclusao maior 
tempo_TCMaior(Fr,[],0):-!.
tempo_TCMaior(Fr,[Op|LOp],TCMaior):-
	op_prod_client(Op,_,Fr2,_,_,_,TPrazo,TSetup,TExec),
	tempo_TCMaior(Fr2,LOp,TCMaior1),
	((TPrazo > TCMaior1,!,TCMaior is TPrazo);TCMaior is TCMaior1).




% A*
aStar(M,Cam,Custo):-  

operacoes_atrib_maq(M,Lfaltam),  

aStar2([(_,0,[],Lfaltam)],Cam,Custo). % dá inicio ao algoritmo sendo custo inicial igual a  0. 

 
 

% estando a lista de operações que faltam vazia o predicado termina 

aStar2([(_,Custo,T,[])|_],Cam,Custo):- 

    reverse(T,Cam). % inverte a lista final  

 
 

% predicado recursivo 
aStar2([(_,Ca,LTratadas,Lfaltam)|Outros],Cam,Custo):- 

    findall((CEX,CaX,[X|LTratadas],Lfaltam2),  

         (Lfaltam\==[],  

         apaga1(X,Lfaltam,Lfaltam2), % elimina-se a seguinte operação de Lfaltam e guarda-se a lista resultante em Lfaltam2 

          classif_operacoes(X,Opt), % encontra o tipo de maquina relativo á operação 

          operacao_maquina(Opt,M,Fer,TS,_),   ((mesma_ferramenta(M,LTratadas, Fer),!,CustoX is 0);CustoX is TS), % sendo a  ferramenta a mesma o tempo de setup não altera pois não vai haver mudança 

            \+ member(X,Lfaltam2), % verifica se a operação não é membro da lista que falta 

                CaX is CustoX + Ca, % Soma o custo das operações anteriores 

                elimina_mesma_ferramenta(M,Fer,Lfaltam2, LSemFer), 

                estimativa(LSemFer,EstX), % Realiza a estimativa 

                CEX is CaX +EstX), % Soma os novos valores ao custo com a estimativa 

                Novos), % Guarda os resultados obtidos em Novos 

    append(Outros,Novos,Todos), % Junta Outros com Novos guardando em Todos. 

    sort(Todos,TodosOrd), % Ordena  guardando em TodosOrd 

    filtrar_cabeca(TodosOrd, CabecaSorted),  

aStar2(CabecaSorted,Cam,Custo). % predicado recursivo 

 
 

mesma_ferramenta(M, [OpAct|_], Fer):- 

    buscar_ferramenta(M, OpAct, Fer).  
 

buscar_ferramenta(M, Actual,Fer):- 

    classif_operacoes(Actual, Tipo), % retorna tipo da operação 

    operacao_maquina(Tipo,M,Fer,_,_).  
 
 

swap_length([(CEX1,CaX1,Lpercorridas1,Lfaltam1),(CEX2,CaX2,Lpercorridas2,Lfaltam2)|T],[(CEX2,CaX2,Lpercorridas2,Lfaltam2) ,(CEX1,CaX1,Lpercorridas1,Lfaltam1)|T]):- 

    CEX1==CEX2, % filtra apenas se o custo for igual 

    length(Lfaltam1, Len1), % length da lista 1 

    length(Lfaltam2, Len2), % length da lista 2 

    Len1>Len2. % só troca se a lista 1 for maior que a 2  

swap_length([Z|T],[Z|TT]):- swap_length(T,TT). % predicado recursivo. 

 

 

filtrar_cabeca(L,S):- 

    swap_length(L,LS), !, filtrar_cabeca(LS,S). 

filtrar_cabeca(S,S). 

 
 

%elimina todas as operaçoes que usem a mesma ferramenta 

elimina_mesma_ferramenta(_,_,[], []). 

 
 

elimina_mesma_ferramenta(M, Fer, [Op|Lfaltam], L1):- 

    ((buscar_ferramenta(M, Op, Fer),!,elimina_mesma_ferramenta(M,Fer, Lfaltam, L1));false). 

 
 

elimina_mesma_ferramenta(M, Fer, [Op|Lfaltam], [Op|L1]):- 

    elimina_mesma_ferramenta(M, Fer, Lfaltam,L1). 

 
 
 

estimativa(LOp,Estimativa):- 

    findall(p(FOp,Tsetup), 

    (member(Op,LOp),op_prod_client(Op,_,FOp,_,_,_,_,Tsetup,_)), 

    LFTsetup), 

    elimina_repetidos(LFTsetup,L), 

    soma_setups(L,Estimativa). 

 

soma_setups([],0). 

soma_setups([p(_,Tsetup)|L],Ttotal):- soma_setups(L,T1), Ttotal is Tsetup+T1. 
 

elimina_repetidos([],[]). 

elimina_repetidos([X|L],L1):-member(X,L),!,elimina_repetidos(L,L1). 

elimina_repetidos([X|L],[X|L1]):-elimina_repetidos(L,L1). 

 