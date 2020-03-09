
function criarMaquinasDB(linha, maquina, text) {
    var loaderGLTF = new THREE.GLTFLoader();

    // console.log("linha: " + linha);
    // console.log("maquina: " + maquina);
    // console.log("text: " + text);

    var res = text.split(":");
    var res1 = [];
    // console.log("DIVIDIDOOOOO:");
    // for (var z = 0; z <= res.length; z++) {
    //     console.log(res[z]);
    // }

    //descricao
    var descricaoAux = res[1].split(",");
    var descricaoAux1 = descricaoAux[0];
    //tirar ""
    var descricao = descricaoAux1.substr(1).slice(0, -1);
    // console.log(descricao);

    //marca
    var marcaAux = res[2].split(",");
    var marcaAux1 = marcaAux[0];
    var marca = marcaAux1.substr(1).slice(0, -1);
    // console.log(marca);

    //modelo
    var modeloAux = res[3].split(",");
    var modeloAux1 = modeloAux[0];
    var modelo = modeloAux1.substr(1).slice(0, -1);
    // console.log(modelo);

    //posicao
    var tipoMaquinaAux = res[4].split(",");
    var tipoMaquinaAux1 = tipoMaquinaAux[0];
    var tipoMaquina = tipoMaquinaAux1.substr(1).slice(0, -2);
    // console.log(tipoMaquina);




    loaderGLTF.load("models/maquina2/oewww.glb",
        function (gltf) {
            nMaquinas = 30 * (maquina - 1);
            nLinhas = 60 * linha;
            //2 robo
            gltf.scene.scale.set(0.25, 0.25, 0.25);
            gltf.scene.rotation.set(0, 0, 0);
            // console.log("Tamanho:");
            var model = gltf.scene.clone();
            model.position.set(-90 + nMaquinas, -5, -25 + nLinhas);
            model.traverse(function (child) {
                //create a global var to reference later when changing textures
                //apply texture
                child.name = "Descricao: " + descricao;
                child.marca = "Marca: " + marca;
                child.modelo = "Modelo: " + modelo;
                child.tipoMaquina = "Tipo de maquina: " + tipoMaquina;
                child.maquinaX = model.position.x;
                // child.maquinaY = model.position.y;
                child.maquinaZ = model.position.z;
                child.numero = n;

            });
            n++;
            // Sombras
            model.traverse(function (node) {

                node.castShadow = true;
                node.receiveShadow = true;

            });



            scene.add(model);
            maquinasGLTF.push(model);

        });

}


function criarLinhaProducaoDB(nrLinhas) {

    var loaderGLTF = new THREE.GLTFLoader();
    var a;
    //passadeira

    for (a = 0; a < nrLinhas; a++) {

        loaderGLTF.load("models/tapete/scene.gltf",
            function (gltf) {
                //console.log(boolean)
                gltf.scene.scale.set(22, 22, 110);
                gltf.scene.position.set(-40, -2.5, 0 + distanciaLinhas - 45);
                gltf.scene.rotation.set(0, 1.57, 0);
                var numeroDaLinha = 1;

                gltf.scene.traverse(function (child) {
                    //create a global var to reference later when changing textures
                    //apply texture
                    child.name = "Linha de producao ";

                });
                numeroDaLinha++;

                // Sombras
                gltf.scene.traverse(function (node) {

                    node.castShadow = true;
                    node.receiveShadow = true;

                });
                scene.add(gltf.scene);
                distanciaLinhas += 60;
                // if (nLinha % 2 == 0) {
                //     distanciaLinhas += 40;
                // }

            });
    }

}


function enviarEncomenda() {
    if (booleanCamiao == false) {
        booleanCamiao = true;

        //start play
        audioLoader.load('sounds/diesel-truck.mp3', function (buffer) {


            truckInitialSound.setBuffer(buffer);
            truckInitialSound.play();
        });
        //horn play
        audioLoader.load('sounds/truck-horn.mp3', function (buffer) {


            truckSound.setBuffer(buffer);
            truckSound.play();
        });
    }

}

function apagarTudo() {
    //fork
    location.reload();
}

function criarTexto() {

    // TEXT
    var loadertext = new THREE.FontLoader();
    loadertext.load('textures/Regular.json', function (font) {
        var textGeo = new THREE.TextBufferGeometry("www.MyOwnCutlery.com", {
            font: font,
            size: 10,
            height: 5,
            curveSegments: 2,
            bevelThickness: 1,
            bevelSize: 0.2,
            bevelEnabled: true
        });

        textGeo.computeBoundingBox();
        var centerOffset = - 0.5 * (textGeo.boundingBox.max.x - textGeo.boundingBox.min.x);
        var textMaterial = new THREE.MeshPhongMaterial({ color: 0xffd300, specular: 0xffffff });
        var mesh = new THREE.Mesh(textGeo, textMaterial);
        mesh.position.x = centerOffset;
        mesh.position.y = 40;
        mesh.position.z = -68.5;
        mesh.castShadow = true;
        mesh.receiveShadow = true;



        scene.add(mesh);
    });
}

function criarGarfoNaLinha() {
    //fork
    var loaderGLTF = new THREE.GLTFLoader();

    loaderGLTF.load("models/fork/scene.gltf",
        function (gltf) {
            gltf.scene.scale.set(2, 2, 2);
            gltf.scene.position.set(-66, 13, 15);
            gltf.scene.rotation.set(0, 1.57, 0);
            var model = gltf.scene.clone();
            var model1 = gltf.scene.clone();
            var model2 = gltf.scene.clone();
            var model3 = gltf.scene.clone();

            model1.position.set(-5, 13, 15);
            model2.position.set(-130, 13, 15);
            model3.position.set(-10, 13, 135);

            model.traverse(function (child) {
                child.name = "Garfo";
            });
            model1.traverse(function (child) {
                child.name = "Garfo1";
            });
            model2.traverse(function (child) {
                child.name = "Garfo2";
            });
            model3.traverse(function (child) {
                child.name = "Garfo2";
            });

            
            scene.add(model);
            scene.add(model1);
            scene.add(model2);
            scene.add(model3);

            objectsGLTF.push(model);
            objectsGLTF.push(model1);
            objectsGLTF.push(model2);
            objectsGLTF.push(model3);

            eixoy = objectsGLTF[1].position.y;
            scalez = objectsGLTF[1].scale.z;
            booleanAndarGarfo = true;
        });
}

function criarFacaNaLinha() {
    //knife
    var loaderGLTF = new THREE.GLTFLoader();

    loaderGLTF.load("models/knife/scene.gltf",
        function (gltf) {
            gltf.scene.scale.set(0.06, 0.06, 0.06);
            gltf.scene.position.set(-66, 19.3, -42.3);
            gltf.scene.rotation.set(-1.57, 0, 1.57/3.5);
            var model = gltf.scene.clone();
            var model1 = gltf.scene.clone();
            model1.position.set(-5, 19.3, -42.3);

            model.traverse(function (child) {
                child.name = "Faca";
            });
            model1.traverse(function (child) {
                child.name = "Faca1";
            });
      

            scene.add(model);
            scene.add(model1);
          

            facasGLTF.push(model);
            facasGLTF.push(model1);
           

            eixoyfaca = facasGLTF[0].position.y;
            scalezfaca = facasGLTF[0].scale.z;
            booleanAndarFacas = true;
            
        });

}

function criarColherNaLinha() {
    //spoon
    var loaderGLTF = new THREE.GLTFLoader();

    loaderGLTF.load("models/spoon/scene.gltf",
        function (gltf) {
            gltf.scene.scale.set(1.2, 1.2, 1.2);
            gltf.scene.position.set(-66, 13.8, 75);
            gltf.scene.rotation.set(0, 1.57, 0);
            var model = gltf.scene.clone();
            var model2 = gltf.scene.clone();
            var model3 = gltf.scene.clone();
            model2.position.set(-130, 13.8, 75);
            model3.position.set(-130, 13.8, 135);

            model.traverse(function (child) {
                child.name = "Colher";
            });

            model2.traverse(function (child) {
                child.name = "Colher1";
            });
           
            model3.traverse(function (child) {
                child.name = "Colher2";
            });

            scene.add(model);

            scene.add(model2);

            scene.add(model3);

            colherGLTF.push(model);
 
            colherGLTF.push(model2);

            colherGLTF.push(model3);

            eixoycolher = colherGLTF[1].position.y;
            scalezcolher = colherGLTF[1].scale.z;

            booleanAndarColher = true;
        });
}

function robotArm(nrLinhas) {

    var loaderGLTF = new THREE.GLTFLoader();
    //robot animated
    var dist=0;
    for(var a=0;a<(nrLinhas-1);a++){
    loaderGLTF.load("models/robot/scene.gltf",
        function (gltf) {

            gltf.scene.scale.set(0.012, 0.012, 0.012);
            gltf.scene.position.set(106, -3.5, 17+dist);
            gltf.scene.rotation.set(0, 3.14, 0);

            const animation = gltf.animations[0];

            var model = gltf.scene.clone();
            const mixer = new THREE.AnimationMixer(model);
            mixers.push(mixer);

            const action = mixer.clipAction(animation);
            action.play();

            var text = "Maquina de envio encomendas"
            model.traverse(function (child) {
                //create a global var to reference later when changing textures
                //apply texture

                child.name = text;
            });

            model.traverse(function (node) {

                if (node.isMesh || node.isLight) node.castShadow = true;
                if (node.isMesh || node.isLight) node.receiveShadow = true;

            });
            scene.add(model);
            dist+=60;
        });
    }
}

function criarCaixaEspecial() {

    var loaderGLTF = new THREE.GLTFLoader();

    loaderGLTF.load("models/specialbox/scene.gltf",
        function (gltf) {
            gltf.scene.scale.set(0.5, 0.5, 0.5);
            gltf.scene.position.set(78, -2, -45);
            gltf.scene.rotation.set(0, -(3.14 / 2), 0);
            var model = gltf.scene.clone();
            model.traverse(function (child) {
                child.name = "";
            });
            scene.add(model);

        });
}


function criarOutros() {

    var loaderGLTF = new THREE.GLTFLoader();
    //y,z,x

    //numero de linhas 
    var nLinhas = 4;

    //maquinas por linha
    var linhasPorMaquina = [];
    var linha1Maquinas = 2;
    var linha2Maquinas = 1;
    var linha3Maquinas = 3;
    var linha4Maquinas = 2;
    // linhasPorMaquina.push(linhasPorMaquina1);
    // linhasPorMaquina.push(linhasPorMaquina2);
    // linhasPorMaquina.push(linhasPorMaquina3);
    // linhasPorMaquina.push(linhasPorMaquina4);


    //texto teste
    var arraytext = [];
    var text = "Maquina 1 " + "Modelo: BMX "
    var text1 = "Maquina 2 " + "Modelo: Moutain "
    arraytext.push(text);
    arraytext.push(text1);


    //rusty pipe
    loaderGLTF.load("models/tank/scene1.gltf",
        function (gltf) {
            gltf.scene.scale.set(28, 28, 28);
            gltf.scene.position.set(125, 20, -40);
            var model = gltf.scene.clone();
            model.traverse(function (child) {
                child.name = "Just a rusty pipe";
            });
            scene.add(model);

        });

    //prateleira
    loaderGLTF.load("models/prateleira/scene.gltf",
        function (gltf) {
            gltf.scene.scale.set(25, 15, 15);
            gltf.scene.position.set(-115, 20, -65);
            gltf.scene.rotation.set(0, 0, 0);
            var model = gltf.scene.clone();
            var text = ""
            model.traverse(function (child) {
                //create a global var to reference later when changing textures
                //apply texture

                child.name = text;
            });
            scene.add(model);
            // objectsGLTF.push(model);
        });



    //carrinha
    loaderGLTF.load("models/carrinha/scene.gltf",
        function (gltf) {

            gltf.scene.scale.set(10, 10, 10);
            gltf.scene.position.set(215, -3.9, 20);
            gltf.scene.rotation.set(0, 3.14, 0);
            var model = gltf.scene.clone();
            var text = "Camião MyOwnCutlery"
            model.traverse(function (child) {
                //create a global var to reference later when changing textures
                //apply texture

                child.name = text;
            });
            scene.add(model);

            objectsGLTF.push(model)
        });
    
    var dist = 0;
    for(var a=0; a<nGates; a++){


    // black material
    var wallBlackMaterial = new THREE.MeshBasicMaterial({
        map: new THREE.TextureLoader().load('textures/airport.png'),
        side: THREE.DoubleSide
    });

    //black right wall 
    var wallBlackGeometry = new THREE.CubeGeometry(20, 6, 20);
    

    //gate
    loaderGLTF.load("models/gate/scene.gltf",
        function (gltf) {
            console.log("LINHAS");
            console.log(nGates);

            gltf.scene.scale.set(30, 15, 15);
            gltf.scene.position.set(149, 9, 17+dist);
            gltf.scene.rotation.set(0, 3.14, 0);
            var model = gltf.scene.clone();
            var text = ""

            var wallBackLeft = new THREE.Mesh(wallBlackGeometry, wallBlackMaterial);
            wallBackLeft.position.x = 150;
            wallBackLeft.position.y = 7.3;
            wallBackLeft.position.z = 16+dist;
            wallBackLeft.rotation.z += 1.57;
            scene.add(wallBackLeft);

            scene.add(model);
            dist += 60;
        });


    }


    //frame

    loaderGLTF.load("models/frame/scene.gltf",
        function (gltf) {
            gltf.scene.scale.set(2, 2, 2);
            gltf.scene.rotation.set(0, -3.14 / 2, 0);
            gltf.scene.position.set(-100, 36.5, -59);
            scene.add(gltf.scene);
        });

}


