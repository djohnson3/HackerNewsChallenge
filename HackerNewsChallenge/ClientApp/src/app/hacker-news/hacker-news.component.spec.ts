import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HackerNewsComponent } from './hacker-news.component'
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClientTestingModule } from '@angular/common/http/testing';




describe('HackerNewsComponent', () => {
    let component: HackerNewsComponent;
    let fixture: ComponentFixture<HackerNewsComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
          declarations: [ HackerNewsComponent ],
          imports: [ NgxPaginationModule, HttpClientTestingModule ],
          providers: [
            {
              provide: 'BASE_URL',
              useValue: {
                BASE_URL: 'https://localhost:5001/',
              },
            },
          ],
        })
        .compileComponents();
    }));
    
    beforeEach(() => {
        fixture = TestBed.createComponent(HackerNewsComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });


    it('should display a title', async(() => {
        const titleText = fixture.nativeElement.querySelector('h1').textContent;
        expect(titleText).toEqual('Hacker News Top Stories');
    }));
    
    
    it('should display loading...', async(() => {
      const titleText = fixture.nativeElement.querySelector('em').textContent;
      expect(titleText).toEqual('Loading...');
  }));

  
  it('should display display Clear Search button', async(() => {
    const titleText = fixture.nativeElement.querySelector('button').textContent;
    expect(titleText).toEqual('Clear Search');
}));

});