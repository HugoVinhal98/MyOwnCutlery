function skyBox() {
    // skyBox
    var skyBoxGeometry = new THREE.CubeGeometry(2000, 2000, 2000);
    var cubeSkyBoxMaterials =
        [
            new THREE.MeshBasicMaterial({ map: new THREE.TextureLoader().load('textures/front.png'), side: THREE.DoubleSide }),
            new THREE.MeshBasicMaterial({ map: new THREE.TextureLoader().load('textures/back.png'), side: THREE.DoubleSide }),
            new THREE.MeshBasicMaterial({ map: new THREE.TextureLoader().load('textures/top.png'), side: THREE.DoubleSide }),
            new THREE.MeshBasicMaterial({ map: new THREE.TextureLoader().load('textures/down.png'), side: THREE.DoubleSide }),
            new THREE.MeshBasicMaterial({ map: new THREE.TextureLoader().load('textures/left.png'), side: THREE.DoubleSide }),
            new THREE.MeshBasicMaterial({ map: new THREE.TextureLoader().load('textures/right.png'), side: THREE.DoubleSide })
        ];

    var skyBoxMaterial = new THREE.MeshFaceMaterial(cubeSkyBoxMaterials);
    var skyBox = new THREE.Mesh(skyBoxGeometry, skyBoxMaterial);
    scene.add(skyBox);
}