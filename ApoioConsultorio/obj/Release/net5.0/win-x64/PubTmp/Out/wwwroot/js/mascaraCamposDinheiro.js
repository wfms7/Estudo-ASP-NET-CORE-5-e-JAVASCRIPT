
$(document).ready(function () {

    const listaCampoCoin = document.querySelectorAll('.coin');
    let contador = 0;
    while (contador < listaCampoCoin.length) {

        $("#" + listaCampoCoin[contador].id).mask("999.999.990,00", { reverse: true });

        contador = contador + 1;
    }


    /*
      $("#ValorAvista").mask("999.999.990,00", { reverse: true })
      $("#ValorParcelado").mask("999.999.990,00", { reverse: true })
      $("#MaterialCustos_1").mask("999.999.990,00", { reverse: true })
      $("#MaterialCustos_2").mask("999.999.990,00", { reverse: true })
      $("#MaterialCustos_3").mask("999.999.990,00", { reverse: true })
      $("#MaterialCustos_4").mask("999.999.990,00", { reverse: true })
      $("#EquipeCustos1").mask("999.999.990,00", { reverse: true })
      $("#EquipeCustos2").mask("999.999.990,00", { reverse: true })
      $("#EquipeCustos3").mask("999.999.990,00", { reverse: true })
      $("#EquipeCustos4").mask("999.999.990,00", { reverse: true })
    */
})
