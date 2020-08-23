import { Component, OnInit } from '@angular/core';
import { ConversionModel } from 'src/app/shared/models/conversion-model';
import { Unit } from 'src/app/shared/models/unit-types';
import { RecipeService } from 'src/app/core/services/recipe.service';
import { UnitService } from 'src/app/core/services/unit.service';

@Component({
  selector: 'app-unit-conversion',
  templateUrl: './unit-conversion.component.html',
  styleUrls: ['./unit-conversion.component.scss']
})
export class UnitConversionComponent implements OnInit {

  conversionUnits: ConversionModel;
  conversionTemperature: ConversionModel;
  unitTypes: Unit[];
  temperatureUnits: Unit[];

  constructor(
    private recipeService: RecipeService,
    private unitService: UnitService
  ) {
    this.conversionUnits = new ConversionModel();
    this.conversionTemperature = new ConversionModel();
   }

  async ngOnInit() {
    this.unitTypes = await this.recipeService.getUnits().toPromise();
    this.temperatureUnits = [
      {id: 0, unitName: 'celsius', unitAbbreviation: 'c', unitType: 4 },
      {id: 0, unitName: 'fahrenheit', unitAbbreviation: 'f', unitType: 4 }
    ];
  }

  clearUnits(){
    this.conversionUnits.quantityFrom = 0;
    this.conversionUnits.quantityTo = 0;
    this.conversionUnits.unitFrom = null;
    this.conversionUnits.unitTo = null;
  }

  clearTemperature(){
    this.conversionTemperature.quantityFrom = 0;
    this.conversionTemperature.quantityTo = 0;
    this.conversionTemperature.unitFrom = null;
    this.conversionTemperature.unitTo = null;
  }

  convertUnits(){
    this.unitService.convertUnits(this.conversionUnits).subscribe(data => {
      this.conversionUnits.quantityTo = data.quantityTo;
    });
  }

  convertTemperature(){
    
    console.log(this.conversionTemperature);
    this.unitService.convertTemperature(this.conversionTemperature).subscribe(data => {
      this.conversionTemperature.quantityTo = data.quantityTo;
    });
  }
}
