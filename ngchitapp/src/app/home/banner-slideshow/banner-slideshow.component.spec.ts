import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BannerSlideshowComponent } from './banner-slideshow.component';

describe('BannerSlideshowComponent', () => {
  let component: BannerSlideshowComponent;
  let fixture: ComponentFixture<BannerSlideshowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BannerSlideshowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BannerSlideshowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
