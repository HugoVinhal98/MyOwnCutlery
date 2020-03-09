function luzes() {

    scene.add(new THREE.AmbientLight(0x222222));

    // cubo com as coordenadas da luz
    var geometryLight = new THREE.BoxGeometry(1, 1, 1);
    var lightMaterial = new THREE.MeshBasicMaterial({ color: 0xfff2e6 });


    // cubo representativo da lampada
    // var cubeLight = new THREE.Mesh(geometryLight, lightMaterial);
    // scene.add(cubeLight);

    // var cubeLight2 = new THREE.Mesh(geometryLight, lightMaterial);
    // scene.add(cubeLight2);

    // var cubeLight3 = new THREE.Mesh(geometryLight, lightMaterial);
    // scene.add(cubeLight3);



    var spotLight = new THREE.SpotLight(0xfff2e6, 0.8);
    spotLight.position.set(-50, 200, 20);
    spotLight.angle = 10;
    spotLight.target.position.set(-50, 0, 20);
    spotLight.castShadow = true;
    spotLight.shadow.camera.fov = 40;
    spotLight.target.updateMatrix();


    var spotLight2 = new THREE.SpotLight(0xfff2e6, 100);
    spotLight2.position.set(115, 140, -15);
    spotLight2.angle = 0.20;
    spotLight2.distance = 130;
    spotLight2.target.position.set(120, 0, -40);
    spotLight2.castShadow = true;
    spotLight2.shadow.camera.fov = 30;
    spotLight2.target.updateMatrix();

    //maquinas robot arm light
    var spotLight2v2 = new THREE.SpotLight(0xfff2e6, 400);
    spotLight2v2.position.set(100, 140, 20);
    spotLight2v2.angle = 0.20;
    spotLight2v2.distance = 140;
    spotLight2v2.target.position.set(100, 0, 20);
    spotLight2v2.castShadow = true;
    spotLight2v2.shadow.camera.fov = 30;
    spotLight2v2.target.updateMatrix();
    
    var spotLight2v3 = new THREE.SpotLight(0xfff2e6, 400);
    spotLight2v3.position.set(100, 140, 80);
    spotLight2v3.angle = 0.20;
    spotLight2v3.distance = 140;
    spotLight2v3.target.position.set(100, 0, 80);
    spotLight2v3.castShadow = true;
    spotLight2v3.shadow.camera.fov = 30;
    spotLight2v3.target.updateMatrix();

    var spotLight2v4 = new THREE.SpotLight(0xfff2e6, 400);
    spotLight2v4.position.set(100, 140, 140);
    spotLight2v4.angle = 0.20;
    spotLight2v4.distance = 140;
    spotLight2v4.target.position.set(100, 0, 140);
    spotLight2v4.castShadow = true;
    spotLight2v4.shadow.camera.fov = 30;
    spotLight2v4.target.updateMatrix();

    var spotLight2v5 = new THREE.SpotLight(0xfff2e6, 400);
    spotLight2v5.position.set(100, 140, 200);
    spotLight2v5.angle = 0.20;
    spotLight2v5.distance = 140;
    spotLight2v5.target.position.set(100, 0, 200);
    spotLight2v5.castShadow = true;
    spotLight2v5.shadow.camera.fov = 30;
    spotLight2v5.target.updateMatrix();
    

    var spotLight3 = new THREE.SpotLight(0xfff2e6, 0.7);
    spotLight3.position.set(0, 200, 170);
    spotLight3.angle = 4;
    spotLight3.target.position.set(0, 0, 170);
    spotLight3.castShadow = true;
    spotLight3.shadow.camera.fov = 60;
    spotLight3.target.updateMatrix();


    scene.add(spotLight.target, spotLight);
    scene.add(spotLight2.target, spotLight2);
    scene.add(spotLight2v2.target, spotLight2v2);
    scene.add(spotLight2v3.target, spotLight2v3);
    scene.add(spotLight2v4.target, spotLight2v4);
    scene.add(spotLight2v5.target, spotLight2v5);
    scene.add(spotLight3.target, spotLight3);

    //Set up shadow properties for the light
    spotLight.shadow.mapSize.width = 512;  // default
    spotLight.shadow.mapSize.height = 512; // default
    spotLight.shadow.camera.near = 0.5;    // default
    spotLight.shadow.camera.far = 2000;     // default

    spotLight2.shadow.mapSize.width = 512;  // default
    spotLight2.shadow.mapSize.height = 512; // default
    spotLight2.shadow.camera.near = 0.5;    // default
    spotLight2.shadow.camera.far = 2000;     // default

    spotLight3.shadow.mapSize.width = 512;  // default
    spotLight3.shadow.mapSize.height = 512; // default
    spotLight3.shadow.camera.near = 0.8;    // default
    spotLight3.shadow.camera.far = 2000;     // default
    // spotLight3.shadow.camera.fov = 2000;     // default

    var light = new THREE.DirectionalLight(0xffffff, 1.2, 100);
    light.position.set(250, 3, 0);             //default; light shining from top
    light.castShadow = true;            // default false
    scene.add(light);


    //helpers
    // var helper = new THREE.CameraHelper(spotLight.shadow.camera);
    // var helper1 = new THREE.CameraHelper(spotLight2v2.shadow.camera);
    // var helper2 = new THREE.CameraHelper(spotLight3.shadow.camera);

    // scene.add(helper);
    // scene.add(helper1);
    // scene.add(helper2);


    lights.push(spotLight);
    lights.push(spotLight2);
    lights.push(spotLight3);
    lights.push(spotLight2v2);
    lights.push(spotLight2v3);
    lights.push(spotLight2v4);
    lights.push(spotLight2v5);



}

function luzesDesligadas() {
    if (lights[0].visible == true) {
        for (var l = 0; l < lights.length; l++) {
            lights[l].visible = false;
        }
    } else {
        for (var l = 0; l < lights.length; l++) {
            lights[l].visible = true;
        }
    }
}
