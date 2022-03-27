import { Component, OnInit } from '@angular/core';
import { IProduct} from './Product'
import { ProductService } from './product.service';


@Component({
    
    templateUrl: './Product-list.component.html',
    styleUrls: ['./product-list.component.css']
    })

    export class ProductListComponent implements OnInit
    {
    

        myPageTitle:string="Product List";
        imageWidth: number = 50;
        imageMargin: number = 2;
        showImage: boolean = false;
        errorMessage:string;

        _listFilter: string;
        get listFilter():string
        {
            return this._listFilter;
        }
        set listFilter(value:string)
        {
            this._listFilter=value;
            this.filteredProducts=this.listFilter ? this.performFilter(this.listFilter) : this.products
        }

        filteredProducts=[];
        products: IProduct[] = [];


          constructor(private productService: ProductService) {
            this.filteredProducts = this.products;
            this.listFilter = 'cart';
          }

          toggleImage():void{
            this.showImage=!this.showImage;
          }

          ngOnInit(): void {
            console.log("On Init")
            this.productService.getProducts().subscribe({
                next : products => 
                {
                    this.products=products;
                    this.filteredProducts = this.products;
                },
                error: err=>this.errorMessage=err
            });
            
        } 

        performFilter(filterBy: string): IProduct[] {
            filterBy = filterBy.toLocaleLowerCase();
            return this.products.filter((product: IProduct) =>
              product.productName.toLocaleLowerCase().indexOf(filterBy) !== -1);
          }

          onRatingClicked(message: string): void {
            this.myPageTitle = 'Product List: ' + message;
          }
    }