//During the test the env variable is set to test
process.env.NODE_ENV = 'test';

let mongoose = require("mongoose");
let Cliente = require('../Models/Cliente');

//Require the dev-dependencies
let chai = require('chai');
let chaiHttp = require('chai-http');
let server = require('../servermock');
let should = chai.should();

chai.use(chaiHttp);
//Our parent block
describe('Clientes', () => {
    /* beforeEach((done) => { //Before each test we empty the database
        Cliente.remove({}, (err) => {
            done();
        });
    }); */

    /*
      * Test the /GET route
      */
    describe('/GET clientes', () => {
        it('it should GET all the clients', (done) => {
            chai.request(server)
                .get('/api/Clientes')
                .end((err, res) => {
                    if (err) {
                        console.log(err);
                    } else {
                        res.should.have.status(200);
                        //res.body.should.be.a('array');
                        done();
                    }
                });
        });
    });

    describe('/GET permissao', () => {
        it('it should GET permissao de acesso dos clientes', (done) => {
            chai.request(server)
                .get('/api/Clientes/permissao')
                .end((err, res) => {
                    if (err) {
                        console.log(err);
                    } else {
                        res.should.have.status(200);
                        //res.body.should.be.a('array');
                        done();
                    }
                });
        });
    });

    describe('/POST cliente', () => {
        it('it should Post a cliente', (done) => {
            let clienteEnviar = {
                nome: "teste",
                morada: "Rua teste",
                telemovel: 983617452,
                email: "testade@gmail.com",
                password: "password",
            }
            chai.request(server)
                .post('/api/Clientes')
                .send(clienteEnviar)
                .end((err, res) => {
                    res.should.have.status(201);
                    res.body.clienteCriado.should.have.property('nome');
                    res.body.clienteCriado.should.have.property('morada');
                    res.body.clienteCriado.should.have.property('telemovel');
                    res.body.clienteCriado.should.have.property('email');
                    res.body.clienteCriado.should.have.property('password');

                    done();
                });
        });

    });

    describe('/POST permissao a false', () => {
        it('Cancela a permissao de acesso de um user', (done) => {
            let permissao = {
                permissao: "false"
            }
            chai.request(server)
                .post('/api/Clientes/alterarConfiguracao')
                .send(permissao)
                .end((err, res) => {
                    res.should.have.status(200);
                    done();
                });
        });

    });

    describe('/POST permissao a true', () => {
        it('Da permissao de acesso ao user', (done) => {
            let permissao = {
                permissao: "true"
            }
            chai.request(server)
                .post('/api/Clientes/alterarConfiguracao')
                .send(permissao)
                .end((err, res) => {
                    res.should.have.status(200);
                    done();
                });
        });

    });

});