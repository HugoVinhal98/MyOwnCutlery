% F�BRICA

% Linhas

linhas([lA,lB,lC]).

% Maquinas

% as m�quinas mf at� mj s�o iguais �s m�quinas ma at� me e constituem a linha lB igual a lA
% as m�quinas mk at� mm constituem a linha lC 
maquinas([ma,mb,mc,md,me,mf,mg,mh,mi,mj,mk,ml,mm]).

% Ferramentas

% as ferramentas fa1 at� fj1 s�o iguais �s ferramentas fa a fj, sendo usadas pelas m�quinas mf at� mj
 
ferramentas([fa,fb,fc,fd,fe,ff,fg,fh,fi,fj,fa1,fb1,fc1,fd1,fe1,ff1,fg1,fh1,fi1,fj1,fk,fl,fm]).
 
% Maquinas que constituem as Linhas

tipos_maq_linha(lA,[ma,mb,mc,md,me]).
tipos_maq_linha(lB,[mf,mg,mh,mi,mj]).
tipos_maq_linha(lC,[mk,ml,mm]).

% Makespan acumulado que constitui as Linhas

linha_makespan(lA,0).
linha_makespan(lB,0).
linha_makespan(lC,0).

operacao_maquina(opt1,ma,fa,1,1).
operacao_maquina(opt2,mb,fb,2.5,2).
operacao_maquina(opt3,mc,fc,1,3).
operacao_maquina(opt4,md,fd,1,1).
operacao_maquina(opt5,me,fe,2,3).
operacao_maquina(opt6,mb,ff,1,4).
operacao_maquina(opt7,md,fg,2,5).
operacao_maquina(opt8,ma,fh,1,6).
operacao_maquina(opt9,me,fi,1,7).
operacao_maquina(opt10,mc,fj,20,2).
operacao_maquina(opt1,mf,fa1,1,1).
operacao_maquina(opt2,mg,fb1,2.5,2).
operacao_maquina(opt3,mh,fc1,1,3).
operacao_maquina(opt4,mi,fd1,1,1).
operacao_maquina(opt5,mj,fe1,2,3).
operacao_maquina(opt6,mg,ff1,1,4).
operacao_maquina(opt7,mi,fg1,2,5).
operacao_maquina(opt8,mf,fh1,1,6).
operacao_maquina(opt9,mj,fi1,1,7).
operacao_maquina(opt10,mh,fj1,20,2).
operacao_maquina(opt11,mk,fk,3,2).
operacao_maquina(opt12,ml,fl,1,4).
operacao_maquina(opt13,mm,fm,1,3).

% PRODUTOS

% os produtos pA at� pF podem ser fabricados em lA ou lB
% os produtos pG at� pJ s� podem ser fabricados em lC

produtos([pA,pB,pC,pD,pE,pF,pG,pH,pI,pJ]).

operacoes_produto(pA,[opt1,opt2,opt3,opt4,opt5]).
operacoes_produto(pB,[opt1,opt6,opt3,opt4,opt5]).
operacoes_produto(pC,[opt1,opt2,opt3,opt7,opt5]).
operacoes_produto(pD,[opt8,opt2,opt3,opt4,opt5]).
operacoes_produto(pE,[opt1,opt2,opt3,opt4,opt9]).
operacoes_produto(pF,[opt1,opt2,opt10,opt4,opt5]).
operacoes_produto(pG,[opt11,opt12,opt13]).
operacoes_produto(pH,[opt11,opt12,opt13]).
operacoes_produto(pI,[opt11,opt12,opt13]).
operacoes_produto(pJ,[opt11,opt12,opt13]).

% ENCOMENDAS

%Clientes

clientes([clA,clB,clC,clD,clE,clF,clG]).

% prioridades dos clientes

prioridade_cliente(clA,2).
prioridade_cliente(clB,1).
prioridade_cliente(clC,3).
prioridade_cliente(clD,1).
prioridade_cliente(clE,1).
prioridade_cliente(clF,1).
prioridade_cliente(clG,1).

% Encomendas do cliente, 
% termos e(<produto>,<n.unidades>,<tempo_conclusao>)
encomenda(clA,[e(pA,4,50)],235).
encomenda(clB,[e(pC,3,30)],194).
encomenda(clC,[e(pE,4,60)],265).
encomenda(clD,[e(pG,5,40)],190).
encomenda(clE,[e(pH,3,30)],182).
encomenda(clF,[e(pI,4,60)],301).
encomenda(clG,[e(pJ,5,140)],280).

% tarefa(Id,TempoProcessamento,TempConc,PesoPenalizacao).
tarefa(t1,2,5,1).
tarefa(t2,4,7,6).
tarefa(t3,1,11,2).
tarefa(t4,3,9,3).
tarefa(t5,3,8,2).

% tarefas(NTarefas).
tarefas(5).

%Criação dinamica

:- dynamic operacoes_atrib_maq/2.
:- dynamic classif_operacoes/2.
:- dynamic op_prod_client/9.
:- dynamic operacoes/1.

cria_op_enc:-retractall(operacoes(_)),
retractall(operacoes_atrib_maq(_,_)),retractall(classif_operacoes(_,_)),
retractall(op_prod_client(_,_,_,_,_,_,_,_,_)),
        findall(t(Cliente,Prod,Qt,TConc),
        (encomenda(Cliente,LE,_),member(e(Prod,Qt,TConc),LE)),
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

% Tratamento de encomendas para várias linhas
:- dynamic encomendasLinhas/2.

%adicionar encomenda à linha
atribuirEncomenda(Lin,Enc):-
    assertz(encomendasLinhas(Lin,Enc)).

%encomendas de uma linha de produção
encomendasNumaLinha(Lin, Enc):-
          findall(Enc,
      encomendasLinhas(Lin,Enc)
          ,Enc).

% Heuristica balanceamento de linhas idêntica

%• EDD (Earliest Due Date) – as encomendas com tempo de conclusão menor
% são tratadas primeiro

heuristica_TempoConclusaoEDD(Lista):-
	findall(Cliente,encomenda(Cliente,[e(_,_,_)],_),ListaEncomendas),
	bubblesort(ListaEncomendas,Lista).
		
bubblesort(List1,SortList) :-
	    swap(List1,List) , ! ,
	    bubblesort(List,SortList).
bubblesort(SortList,SortList).
	
swap([X,Y|List],[Y,X|List]) :- 
	encomenda(X,[e(_,_,TempConcA)],_),
	encomenda(Y,[e(_,_,TempConcB)],_),
    /* write('a e b: '), write(TempConcA + TempConcB), nl, */
	TempConcA > TempConcB.
    
swap([Z|List],[Z|List1]) :- 
	swap(List,List1).

%Atribuicao de encomendas a linhas, sendo que as encomendas estao
%ordenadas por tesmpos de conclusao e sao atribuidas as linhas com 
%menores valores de makespan.
balanceamentoLinhas :- 
    heuristica_TempoConclusaoEDD(ListaEncomendas),nl,
    write('Encomendas: '), write(ListaEncomendas), nl, nl,
    percorrerEncomendas(ListaEncomendas).

%Atribuicao das encomendas às linhas
percorrerEncomendas([]) :- !.
percorrerEncomendas([H|T]) :-
    linhas(Linhas),
    linhaMenorMakespan(Linhas, 3000, _, LinhaMenor),
    atribuirEncomenda(LinhaMenor,H),
    write('Encomenda '),  write(H),  write(' atribuida a linha '),  write(LinhaMenor), write('.'), nl, nl,
    percorrerEncomendas(T).




%De todas as linhas retorna a que tem menor makespan acumulado
linhaMenorMakespan([],_,LinhaFinal,LinhaFinal) :- !.
linhaMenorMakespan([H|T],  MakespanFinal, LinhaMenor, LinhaFinal) :-
    encomendasNumaLinha(H, Enc),
    makespanTotalLista(Enc,0,MakespanAtual),
    (MakespanAtual < MakespanFinal -> (MakespanFinal1 = MakespanAtual, LinhaMenor1 = H); (MakespanFinal1 = MakespanFinal, LinhaMenor1 = LinhaMenor)),    
    linhaMenorMakespan(T,MakespanFinal1,LinhaMenor1, LinhaFinal).


%Calcula o makespan acumulado de uma linha
makespanTotalLista([],Total,Total) :- !.
makespanTotalLista([H|T],N,Total) :-
    encomenda(H,_,Makespan),
    N1 is N+Makespan,
    makespanTotalLista(T,N1,Total).