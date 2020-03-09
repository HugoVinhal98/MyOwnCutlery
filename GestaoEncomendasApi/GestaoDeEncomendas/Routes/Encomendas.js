const express = require("express");
const router = express.Router();
const checkAuth = require('../Middleware/check-auth');

const EncomendasController = require('../Controllers/EncomendasController');

router.get("/", checkAuth, EncomendasController.getAllEncomendas);

router.get("/quantidade", checkAuth, EncomendasController.getQuantidadeEncomendas);

router.post("/", checkAuth, EncomendasController.postEncomenda);

router.put("/cancelarEncomenda", checkAuth, EncomendasController.cancelarEncomenda);

router.put("/alterarEncomenda", checkAuth, EncomendasController.alterarEncomenda);

router.post("/EncomendaID", checkAuth, EncomendasController.getEncomendaByID);

router.post("/EncomendasUser", checkAuth, EncomendasController.getAllEncomendasUser);

router.put("/solicitarCancelamentoEncomenda", checkAuth, EncomendasController.solicitarCancelamentoEncomenda);

router.put("/solicitarAlteracoesEncomenda", checkAuth, EncomendasController.solicitarAlteracoesEncomenda);

module.exports = router;