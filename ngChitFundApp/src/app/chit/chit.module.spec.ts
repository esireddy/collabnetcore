import { ChitModule } from './chit.module';

describe('ChitModule', () => {
  let chitModule: ChitModule;

  beforeEach(() => {
    chitModule = new ChitModule();
  });

  it('should create an instance', () => {
    expect(chitModule).toBeTruthy();
  });
});
