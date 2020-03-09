//During the test the env variable is set to test
process.env.NODE_ENV = 'test';

let mongoose = require("mongoose");
let Cliente = require('../Models/Encomenda');

//Require the dev-dependencies
let chai = require('chai');
let chaiHttp = require('chai-http');
let server = require('../servermock');
let should = chai.should();


describe('/GET encomendas', () => {
    it('it should GET all the encomendas', (done) => {
        chai.request(server)
            .get('/api/Encomendas')
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

describe('/GET encomendas com mais quantidades', () => {
    it('it should GET all the encomendas mais encomendadas', (done) => {
        chai.request(server)
            .get('/api/Encomendas/quantidade')
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

describe('/POST encomenda', () => {
    it('it should Post a encomenda', (done) => {
        let encomendaEnviar = {
            produto: "produto1",
            quantidade: 100,

        }
        chai.request(server)
            .post('/api/Encomendas')
            .send(encomendaEnviar)
            .end((err, res) => {
                res.should.have.status(201);
                res.body.encomendaCriada.should.have.property('nrEncomenda');
                res.body.encomendaCriada.should.have.property('estado');
                res.body.encomendaCriada.should.have.property('quantidade');
                done();
            });
    });

});

/* describe('/PUT ', () => {
    it('it should UPDATE a encomenda', (done) => {
        chai.request(server)
            .put('/api/Encomendas/alterarEncomenda')
            .send({ nrEncomenda: 21261806, produto: { nome: "produto1" }, quantidade: 1000 })
            .end((err, res) => {
                res.should.have.status(200);
                res.body.should.have.property('message');
                done();
            });
    });
});


describe('/PUT cancelar ', () => {
    it('it should Cancel a encomenda', (done) => {
        chai.request(server)
            .put('/api/Encomendas/cancelarEncomenda')
            .send({ nrEncomenda: 21261806 })
            .end((err, res) => {
                res.should.have.status(200);
                res.body.should.have.property('message');
                done();
            });
    });
}); */