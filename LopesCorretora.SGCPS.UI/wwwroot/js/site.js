/* Write your JavaScript code.*/
function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}

/* Inicio JS Tela = PJ*/
/* Botao adicionar/remover do cadastro de PJ para end. correspondencia*/
function EnderecoCorrespondencia(e) {
    var btn = document.getElementById("btnEnderecoCorrespondencia");
    if (e === "mais") {
        document.getElementById("EnderecoCorrespondencia").style.display = "";
        var funcaoMenos = "EnderecoCorrespondencia('menos')";
        btn.setAttribute('onclick', funcaoMenos);
        btn.setAttribute('class', 'glyphicon glyphicon-minus');
    } else {
        document.getElementById("EnderecoCorrespondencia").style.display = "none";
        var funcaoMais = "EnderecoCorrespondencia('mais')";
        btn.setAttribute('onclick', funcaoMais);
        btn.setAttribute('class', 'glyphicon glyphicon-plus');
    }
}

/* Preenche os campos de endereco obtidos pelo cep na tela de cadastro de PJ*/
function GetCepPj(e) {
    $.ajax({
        type: "GET",
        url: 'https://viacep.com.br/ws/' + $("#CEP").val() + '/json/',
        data: "{}",
        cache: false,
        dataType: "html",
        assync: true,
        success: function (data) {
            var parsed = JSON.parse(data);
            if (parsed.erro !== true) {
                if (e === "fiscal") {
                    document.getElementById("UF").value = parsed.uf;
                    document.getElementById("Rua").value = parsed.logradouro;
                    document.getElementById("Bairro").value = parsed.bairro;
                    document.getElementById("Cidade").value = parsed.localidade;
                } else {
                    document.getElementById("UFCorrespondencia").value = parsed.uf;
                    document.getElementById("RuaCorrespondencia").value = parsed.logradouro;
                    document.getElementById("BairroCorrespondencia").value = parsed.bairro;
                    document.getElementById("CidadeCorrespondencia").value = parsed.localidade;
                }
            } else {
                document.getElementById("UF").value = "";
                document.getElementById("Rua").value = "";
                document.getElementById("Bairro").value = "";
                document.getElementById("Cidade").value = "";
            }
        }
    })
}

// Adiciona campos necessarios para mais um plano na tela de cadastro PJ
function AcrescentarPlano(e) {
    var e = document.getElementById('hiddenQtdDePlanos').value;
    $("#planos")
        .append(
        " <div id='plano_" + e + "'  class='row'> " +
        "     <div class='col-xs-4 col-sm-4 col-md-4'> " +
        "         <div class='form-group'> " +
        "             <label for='ListPlanoPessoaJuridicaMOD_0__NumeroDeBeneficiarios'>Numero De Beneficiarios</label> " +
        "             <input class='form-control' data-val='true' data-val-required='* Campo obrigatorio' id='NumeroDeBeneficiarios' name='NumeroDeBeneficiarios' placeholder='NumeroDoBeneficiarios.' type='text' value='' /> " +
        "             <span class='field-validation-valid text-danger' data-valmsg-for='ListPlanoPessoaJuridicaMOD[0].NumeroDeBeneficiarios' data-valmsg-replace='true'></span> " +
        "         </div> " +
        "     </div> " +
        "     <div class='col-xs-6 col-sm-6 col-md-6'> " +
        "         <div class='form-group'> " +
        "             <label for='ListPlanoPessoaJuridicaMOD_0__PlanoId'>Plano</label> " +
        "             <select class='form-control' data-val='true' data-val-required='The PlanoId field is required.' id='IdPlanoPessoaJuridica' name='PlanoId' size='1'><option value=''>Selecione</option> " +
        "                 <option value='1'>Unimed</option> " +
        "             </select> " +
        "             <span class='field-validation-valid text-danger' data-valmsg-for='ListPlanoPessoaJuridicaMOD[0].PlanoId' data-valmsg-replace='true'></span> " +
        "         </div> " +
        "     </div> " +
        "     <div class='col-xs-1 col-sm-1 col-md-1'> " +
        "         <span style='cursor:pointer; margin-top: 45%' id='btnRemoverPlano' onclick='RemoverPlano(plano_" + e + ")' class='glyphicon glyphicon-minus' />" +
        "     </div> " +
        " </div> ");
    document.getElementById('hiddenQtdDePlanos').value++;
}

function RemoverPlano(id) {
    $(id).remove();
}

/* Fim JS Tela = PJ*/

/* Inicio JS Tela = PF*/
/* Preenche os campos de endereco obtidos pelo cep na tela de cadastro de PF*/
function GetCepPf() {
    $.ajax({
        type: "GET",
        url: 'https://viacep.com.br/ws/' + $("#CEP").val() + '/json/',
        data: "{}",
        cache: false,
        dataType: "html",
        assync: true,
        success: function (data) {
            var parsed = JSON.parse(data);
            if (parsed.erro !== true) {
                document.getElementById("UF").value = parsed.uf;
                document.getElementById("Rua").value = parsed.logradouro;
                document.getElementById("Bairro").value = parsed.bairro;
                document.getElementById("Cidade").value = parsed.localidade;
            } else {
                document.getElementById("UF").value = "";
                document.getElementById("Rua").value = "";
                document.getElementById("Bairro").value = "";
                document.getElementById("Cidade").value = "";
            }
        }
    })
}

function AdicionarDependentes() {
    var QuantidadeDeDependentes = parseInt(document.getElementById("QuantidadeDeDependentes").value);
    var hiddenQtdDependentes = parseInt(document.getElementById("hiddenQtdDependentes").value);

    if (QuantidadeDeDependentes > hiddenQtdDependentes) {
        for (var i = hiddenQtdDependentes; i < QuantidadeDeDependentes; i++) {
            innerDeDependente(i);
            document.getElementById('hiddenQtdDependentes').value = QuantidadeDeDependentes;
        }
    } else if (QuantidadeDeDependentes < hiddenQtdDependentes && QuantidadeDeDependentes >= 0) {
        for (var i = QuantidadeDeDependentes; i < hiddenQtdDependentes; i++) {
            RemoverDependente(document.getElementById("dependente_" + i));
            document.getElementById('hiddenQtdDependentes').value = QuantidadeDeDependentes;
        }
    } else {
        for (var i = 0; i < hiddenQtdDependentes; i++) {
            RemoverDependente(document.getElementById("dependente_" + i));
            document.getElementById('hiddenQtdDependentes').value = 0;
        }
    }
}

function innerDeDependente(id) {
    $("#form-dependente-1")
        .append("<div style='display: block' id='dependente_" + id + "'>" +
        "        <div class='col-xs-12 col-sm-12 col-md-12'> " +
        "            <h4> Dependente " + (parseInt(id) + 1) + " </h4> " +
        "        </div> " +
        "    <div class='row'> " +
        "        <div class='col-xs-12 col-sm-12 col-md-12'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD_" + id + "__Nome'>Nome</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='NomeDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].Nome' placeholder='Nome.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD[" + id + "].Nome' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "    </div> " +
        "    <div class='row'> " +
        "        <div class='col-xs-4 col-sm-4 col-md-4'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD_" + id + "__CPF'>CPF</label> " +
        "                <input class='form-control' id='CPFDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].CPF' placeholder='CPF.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD[" + id + "].CPF' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "        <div class='col-xs-4 col-sm-4 col-md-4'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD_" + id + "__RG'>RG</label> " +
        "                <input class='form-control' id='RGDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].RG' placeholder='RG.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD[" + id + "].RG' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "        <div class='col-xs-2 col-sm-2 col-md-2'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "DataDeNascimento'>Data de nascimento</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='DataDeNascimentoDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].DataDeNascimento' placeholder='Data De Nascimento.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".DataDeNascimento' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "        <div class='col-xs-2 col-sm-2 col-md-2'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "GrauDeParentesco'>Grau de parentesco</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='GrauDeParentescoDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].GrauDeParentesco' placeholder='Grau De Parentesco.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".GrauDeParentesco' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "    </div> " +
        "    <div class='row'> " +
        "        <div class='col-xs-12 col-sm-12 col-md-12'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "NomeDaMae'>Nome da mae</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='NomeDaMaeDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].NomeDaMae' placeholder='Nome Da Mae.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".NomeDaMae' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "    </div> " +
        "    <div class='row'> " +
        "        <div class='col-xs-4 col-sm-4 col-md-4'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "EstadoCivil'>Estado civil</label> " +
        "                <select class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='EstadoCivilDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].EstadoCivil' required='required' size='1'><option value=''>Selecione</option> " +
        "                    <option value='casado'>Casado</option> " +
        "                    <option value='solteiro'>Solteiro</option> " +
        "                </select> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".EstadoCivil' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "        <div class='col-xs-8 col-sm-8 col-md-8'> " +
        "            <div class='form-group'> " +
        "                <label for='LisDependentePessoaFisicaMOD" + id + "NumeroDoSUS'>Numero do SUS</label> " +
        "                <input class='form-control' data-val='true' data-val-required='Campo obrigatorio' id='NumeroDoSUSDependente" + id + "' name='LisDependentePessoaFisicaMOD[" + id + "].NumeroDoSUS' placeholder='Numero Do SUS.' required='required' type='text' value='' /> " +
        "                <span class='field-validation-valid text-danger' data-valmsg-for='LisDependentePessoaFisicaMOD" + id + ".NumeroDoSUS' data-valmsg-replace='true'></span> " +
        "            </div> " +
        "        </div> " +
        "    </div> " +
        "</div>");
}

function RemoverDependente(elem) {
    $(elem).remove();
}

function SplitId(nome) {
    var removido = -1;
    for (var i = 11; i < nome.length; i++) {
        removido = nome[i];
    }
    return removido;
}

/* alert de confirmacao de eclusao pessoa fisica*/
function ExcluirPJ() {
    bootbox.confirm({
        size: "small",
        message: "Deseja realmente excluir este cadastro?",
        callback: function (result) {
            /* result is a boolean; true = OK, false = Cancel*/
            if (result) {
                document.getElementById("AlterarPJ").submit();
            }
        }
    })
}

function mtdAddRowDespesa() {
    var Tipo = document.getElementById('Tipo').value;
    var Valor = document.getElementById('Valor').value;
    var Data = document.getElementById('Data').value;

    $("#TabelaDespesas").append("<tr id= 'tr1' > " +
        "                   <td class='col-lg-4 col-md-4 col-sm-4'> " +
        "                       <input data-val='true' data-val-required='The Id field is required.' name='Tipos' type='hidden' value='" + Tipo + "'> " +
        Tipo +
        "                   </td> " +
        "                   <td class='col-lg-4 col-md-4 col-sm-4'> " +
        "                       <input data-val='true' data-val-required='The Id field is required.' name='Valores' type='hidden' value='" + Valor + "'> " +
        Valor +
        "                   </td> " +
        "                   <td class='col-lg-3 col-md-3 col-sm-3'> " +
        "                       <input data-val='true' data-val-required='The Id field is required.' name='Datas' type='hidden' value='" + Data + "'> " +
        Data +
        "                   </td> " +
        "                   <td class='col-lg-1 col-md-1 col-sm-1'> " +
        "                       <span style='cursor:pointer' name='btnRemover' id='btnRemover1' onclick='mtdRemoveRowDespesa('tr1')' class='glyphicon glyphicon-remove-circle'></span>" +
        "                   </td> " +
        "               </tr> ");
    mtdOrganizarIDsTabelaDespesas();
}

//tela de cadatro de maquina (remove um campo de inserção de sofware)
function mtdRemoveRowDespesa(idTr) {
    var indice = "";
    for (var i = 2; i < idTr.length; i++) {
        indice += idTr[i];
    }
    document.getElementById('TabelaDespesas').deleteRow(indice);
    mtdOrganizarIDsTabelaDespesas();
}

function mtdOrganizarIDsTabelaDespesas() {
    var linhas = document.getElementById('TabelaDespesas').rows;
    var botoes = document.getElementsByName('btnRemover');

    for (var i = 0; i < botoes.length; i++) {
        var mtdRemove = "mtdRemoveRowDespesa('tr" + (i + 1) + "')";
        botoes[i].setAttribute('onclick', mtdRemove);
    }

    for (var i = 0; i < linhas.length; i++) {
        linhas[i].id = "tr" + i;
    }
    return (linhas.length + 1)
}

function RetornarTipo() {
    var Tipos = document.getElementsByName('Tipo');
    var Tipo = "";
    for (var i = 0; i < Tipos.length; i++) {
        if (Tipos[i].checked) {
            Tipo = Tipos[i].value;
            break;
        }
    }
    return Tipo
}

function mtdAddRowComissao() {
    var Tipo = RetornarTipo();
    var Comissao = document.getElementById('Comissao').value;
    var NumeroDaParcela = document.getElementById('NumeroDaParcela').value;

    $("#TabelaComissoes").append("<tr id='tr0' > " +
        "                   <td class='col-lg-4 col-md-4 col-sm-4'> " +
        "                       <input data-val='true' data-val-required='The Id field is required.' name='Tipos' type='hidden' value='" + Tipo + "'> " +
        Tipo +
        "                   </td> " +
        "                   <td class='col-lg-4 col-md-4 col-sm-4'> " +
        "                       <input data-val='true' data-val-required='The Id field is required.' name='NumeroDaParcela' type='hidden' value='" + NumeroDaParcela + "'> " +
        NumeroDaParcela +
        "                   </td> " +
        "                   <td class='col-lg-3 col-md-3 col-sm-3'> " +
        "                       <input data-val='true' data-val-required='The Id field is required.' name='Comissao' type='hidden' value='" + Comissao + "'> " +
        Comissao +
        "                   </td> " +
        "                   <td class='col-lg-1 col-md-1 col-sm-1'> " +
        "                       <span style='cursor:pointer' name='btnRemoverComissao' id='btnRemoverComissao' onclick='mtdRemoveRowComissao('tr0')' class='glyphicon glyphicon-remove-circle'></span>" +
        "                   </td> " +
        "               </tr> ");
    mtdOrganizarIDsTabelaComissao();
}

function mtdOrganizarIDsTabelaComissao() {
    var linhas = document.getElementById('TabelaComissoes').rows;
    var botoes = document.getElementsByName('btnRemoverComissao');

    for (var i = 0; i < botoes.length; i++) {
        var mtdRemove = "mtdRemoveRowComissao('tr" + (i + 1) + "')";
        botoes[i].setAttribute('onclick', mtdRemove);
    }

    for (var i = 0; i < linhas.length; i++) {
        linhas[i].id = "tr" + i;
    }
    return (linhas.length + 1)
}

function mtdRemoveRowComissao(idTr) {
    $(document.getElementById(idTr)).remove();
    mtdOrganizarIDsTabelaComissao();
}