const express = require("express");
const router = express.Router();
const checkAuth = require('../Middleware/check-auth');

const ClientesController = require('../Controllers/ClientesController');

router.get("/", checkAuth, ClientesController.getAllClientes);

router.post("/", checkAuth, ClientesController.postCliente);

router.post("/login", checkAuth, ClientesController.login);

router.put("/alterarCliente", checkAuth, ClientesController.putCliente);

router.put("/alterarClienteAdmin", checkAuth, ClientesController.putClienteAdmin);

router.post("/cliente", checkAuth, ClientesController.postClienteByEmail);

router.put("/apagarcliente", checkAuth, ClientesController.putClienteByEmail);

router.post("/alterarConfiguracao", checkAuth, ClientesController.alterarConfiguracao);

router.get("/permissao", checkAuth, ClientesController.getConfiguracao);

router.post("/alterarConfiguracao2", checkAuth, ClientesController.alterarConfiguracaoCliente);

router.get("/permissao2", checkAuth, ClientesController.getConfiguracaoCliente);




module.exports = router;