import { Component, OnInit, Input } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { ControlTemperaturaDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-controlesde-temperatura',
  templateUrl: './controlesdetemperatura.component.html'
})
export class ControlesdeTemperaturaComponent implements OnInit {

  public lineChartData: ChartDataSets[] = [
    { data: [], label: 'Evolucion de Temperatura' },
  ];
  public lineChartLabels: Label[] = [];
  public lineChartOptions: ChartOptions = {
    responsive: true,
    scales: {
      xAxes: [{
          display: false
      }]
  }
  };
  public lineChartColors: Color[] = [
    {
      borderColor: '#4DB6AC',
      backgroundColor: '#CCEAE7',
    },
  ];
  public lineChartLegend = true;
  public lineChartType: ChartType = 'line';
  public lineChartPlugins = [];

  constructor() { }

  ngOnInit() {
  }


  @Input()
    set evolucion(datos: ControlTemperaturaDto[]) {
        const fechaInicial = new Date();
        fechaInicial.setMonth(fechaInicial.getMonth() - 1);

        /*const ultimoMes = datos.filter(f => 
            new Date(Date.parse(f.fecha.toString())) >= fechaInicial);*/

        this.lineChartData[0].data = datos.map(m => m.temperatura);
        this.lineChartLabels = datos.map(m => `${m.temperatura}  ${new Date(Date.parse(m.fecha.toString())).toLocaleString()}`);
    }

}
