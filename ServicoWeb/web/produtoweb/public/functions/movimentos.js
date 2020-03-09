//movimento do talher 
function movimentoTalherGarfo(eixoy,scalez) {
    // console.log("Talher X: \n")
    // console.log(objectsGLTF[0].position.x)
    i = 0.06;
    if (objectsGLTF[1].position.x > 80) {
        objectsGLTF[1].position.x = -112.5;
        objectsGLTF[1].position.y = eixoy;
        objectsGLTF[1].scale.z = scalez;
    } else if (objectsGLTF[1].position.x < 79 && objectsGLTF[1].position.x > 70 ) {
        objectsGLTF[1].position.x += 0.06;
        objectsGLTF[1].position.y -= 0.06;
        objectsGLTF[1].scale.z -= 0.03;
    }
    if (objectsGLTF[2].position.x >= 80) {
        objectsGLTF[2].position.x = -112.5;
        objectsGLTF[2].position.y = eixoy;
        objectsGLTF[2].scale.z = scalez;

    } else if (objectsGLTF[2].position.x < 79 && objectsGLTF[2].position.x > 70 ) {
        objectsGLTF[2].position.x += 0.06;
        objectsGLTF[2].position.y -= 0.06;
        objectsGLTF[2].scale.z -= 0.03;
    }
    if (objectsGLTF[3].position.x >= 80) {
        objectsGLTF[3].position.x = -112.5;
        objectsGLTF[3].position.y = eixoy;
        objectsGLTF[3].scale.z = scalez;

    } else if (objectsGLTF[3].position.x < 79 && objectsGLTF[3].position.x > 70 ) {
        objectsGLTF[3].position.x += 0.06;
        objectsGLTF[3].position.y -= 0.06;
        objectsGLTF[3].scale.z -= 0.03;
    }
    if (objectsGLTF[4].position.x >= 80) {
        objectsGLTF[4].position.x = -112.5;
        objectsGLTF[4].position.y = eixoy;
        objectsGLTF[4].scale.z = scalez;

    } else if (objectsGLTF[4].position.x < 79 && objectsGLTF[4].position.x > 70 ) {
        objectsGLTF[4].position.x += 0.06;
        objectsGLTF[4].position.y -= 0.06;
        objectsGLTF[4].scale.z -= 0.03;
    }
    objectsGLTF[1].position.x += i;
    objectsGLTF[2].position.x += i;
    objectsGLTF[3].position.x += i;
    objectsGLTF[4].position.x += i;
}


//movimento do talher 
function movimentoTalherFaca(eixoyfaca,scalezfaca) {
    // console.log("Talher X: \n")
    // console.log(objectsGLTF[0].position.x)
    i = 0.4;
    if (facasGLTF[0].position.x > 73) {
        facasGLTF[0].position.x = -112.5;
        facasGLTF[0].position.y = eixoyfaca;
        facasGLTF[0].scale.z = scalezfaca;
    } 
    if (facasGLTF[1].position.x >= 73) {
        facasGLTF[1].position.x = -112.5;
        facasGLTF[1].position.y = eixoyfaca;
        facasGLTF[1].scale.z = scalezfaca;
    }
    
    facasGLTF[0].position.x += i;
    facasGLTF[1].position.x += i;
}


//movimento do colher 
function movimentoTalherColher(eixoycolher,scalezcolher) {
    // console.log("Talher X: \n")
    // console.log(objectsGLTF[0].position.x)
    i = 0.06;
    if (colherGLTF[0].position.x > 73) {
        colherGLTF[0].position.x = -112.5;
        colherGLTF[0].position.y = eixoycolher;
        colherGLTF[0].scale.z = scalezcolher;
    } 
    if (colherGLTF[1].position.x >= 73) {
        colherGLTF[1].position.x = -112.5;
        colherGLTF[1].position.y = eixoycolher;
        colherGLTF[1].scale.z = scalezcolher;
    }
    if (colherGLTF[2].position.x >= 73) {
        colherGLTF[2].position.x = -112.5;
        colherGLTF[2].position.y = eixoycolher;
        colherGLTF[2].scale.z = scalezcolher;
    }
    
    colherGLTF[0].position.x += i;
    colherGLTF[1].position.x += i;
    colherGLTF[2].position.x += i;
}


function movimentoCamiao() {
    // console.log(objectsGLTF[3].position.z)
    if(objectsGLTF[0].position.z < -1100){
        objectsGLTF[0].position.z = 1200;
    }else if( objectsGLTF[0].position.z == 21 ){
        objectsGLTF[0].position.z =20;
        booleanCamiao = false;
    }
    
    objectsGLTF[0].position.z -= 1;

}

function criarLinhasProducao() {
    booleanLinhas = true;
}

function criarMaquinas() {
    booleanMaquinas = true;
}