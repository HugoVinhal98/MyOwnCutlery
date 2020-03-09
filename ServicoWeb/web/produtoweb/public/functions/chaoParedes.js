function criarCubeMachine(nLinhas) {
    // cube machiine
    var cubemachineGeometry = new THREE.CubeGeometry(40, 8, 20);
    var cubemachineMaterial = new THREE.MeshBasicMaterial({
        map: new THREE.TextureLoader().load('textures/airport.png'),
        side: THREE.DoubleSide
    });


    var i = 0;
    for (var a = 0; a < nLinhas; a++) {
        console.log("Nlinhas:")
        console.log(nLinhas);
        var cubemachine = new THREE.Mesh(cubemachineGeometry, cubemachineMaterial);
        cubemachine.position.y = 15 ;
        cubemachine.position.z = -45 +i;
        cubemachine.position.x = -130;

        scene.add(cubemachine);
        i += 60;
    }
}

function chaoParedes() {
    // floor grass
    var floorGeometry1 = new THREE.CubeGeometry(2000, 0.2, 2000);
    var floorMaterial1 = new THREE.MeshBasicMaterial({
        map: new THREE.TextureLoader().load('textures/grass.png'),
        side: THREE.DoubleSide
    });
    var floor1 = new THREE.Mesh(floorGeometry1, floorMaterial1);
    floor1.position.y = -3.1;
    scene.add(floor1);

    // floor 
    var floorGeometry = new THREE.CubeGeometry(300, 1, 350);
    var floorMaterial = new THREE.MeshStandardMaterial({
        map: new THREE.TextureLoader().load('textures/factoryFloor.png'),
        side: THREE.DoubleSide
    });

    var floor = new THREE.Mesh(floorGeometry, floorMaterial);
    floor.position.y = -3;
    floor.position.z = 107;
    floor.receiveShadow = true;
    scene.add(floor);


    // road 
    var roadGeometry = new THREE.CubeGeometry(2500, 0.5, 80);
    var roadMaterial = new THREE.MeshBasicMaterial({
        map: new THREE.TextureLoader().load('textures/road.png'),
        side: THREE.DoubleSide
    });

    var road = new THREE.Mesh(roadGeometry, roadMaterial);
    road.position.y = -2.9;
    road.position.x = 200;
    road.position.z = -170;
    road.rotation.y = (3.14 / 2);
    scene.add(road);
    var road1 = new THREE.Mesh(roadGeometry, roadMaterial);
    road1.position.y = -2.9;
    road1.position.x = 200;
    road1.position.z = -695;
    road1.rotation.y = (3.14 / 2);
    scene.add(road1);


    // wall material
    var wallMaterial = new THREE.MeshBasicMaterial({
        map: new THREE.TextureLoader().load('textures/parede2.jpg'),
        side: THREE.DoubleSide
    });

    // black material
    var wallBlackMaterial = new THREE.MeshBasicMaterial({
        map: new THREE.TextureLoader().load('textures/airport.png'),
        side: THREE.DoubleSide
    });

    // left wall 
    var wallLeftGeometry = new THREE.CubeGeometry(90, 3.5, 350);
    var wallLeft = new THREE.Mesh(wallLeftGeometry, wallMaterial);
    wallLeft.position.x = -150;
    wallLeft.position.y = 7.3;
    wallLeft.position.z = 105;
    wallLeft.rotation.z += 1.57;
    scene.add(wallLeft);

    

    // back wall 
    var backGeometry = new THREE.CubeGeometry(300, 3.5, 90);
    var backwall = new THREE.Mesh(backGeometry, wallMaterial);
    backwall.rotation.x += 1.57;
    backwall.position.z += -68.5;
    backwall.position.y += 7.3;
    scene.add(backwall);

    // right wall 
    var wallright = new THREE.Mesh(wallLeftGeometry, wallMaterial);
    wallright.position.x = 150;
    wallright.position.y = 7.3;
    wallright.position.z = 105;
    wallright.rotation.z += 1.57;
    scene.add(wallright);

}