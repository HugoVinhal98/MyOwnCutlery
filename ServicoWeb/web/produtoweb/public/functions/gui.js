function gui(){

       //GUI
        
       var gui = new dat.GUI({
        height: 5,
        width: 300
    });

    var folder1 = gui.addFolder("Ligação à base de dados");
    var folder2 = gui.addFolder("Encomendas");
    var folder3 = gui.addFolder("Luzes Da Fábrica");
    var folder4 = gui.addFolder("Geral");

    folder1.add(controller, 'CriarLinhasProducao');
    folder1.add(controller, 'CriarMaquinas');
    
    folder2.add(controller1, 'EnviarEncomenda');

    folder4.add(controller2, 'Apagar');

    folder3.add(controller3, 'LigarDesligar');
}