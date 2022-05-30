#define VVA PORTB.F0
#define PULVERIZA PORTB.F1
#define REFRIGERADOR PORTB.F2
#define LAMPADA PORTB.F3
#define ALARME PORTB.F4

void main()
{    
INICIO();    
while (1)
{
ALARME();
NIVEL();
UMIDADE();
TEMPERATURA();
LUMINOSIDADE();        
}
}

int NIVEL=0;
int UMIDADE=0;
int TEMPERATURA=0;
int LUMINOSIDADE=0;
int i = 0;

void INICIO (void)
{
TRISA = 0b11111111;
TRISB = 0;
adcon1 = 0b00001010;
ADC_Init();
}

void ALARME (void)
{
if (LAMPADA == 1 && LUMINOSIDADE <= 200 || TEMPERATURA <= 334 || TEMPERATURA >= 414 ||
NIVEL < 256 || UMIDADE < 870 || UMIDADE > 1003)  
{
ALARME = 1;
}
else
{
ALARME =0;
}

}

void NIVEL (void)
{                   
NIVEL = ADC_Read(0);
delay_ms(15);
  
if (NIVEL < 256)  
{
VVA = 1;
}
else if (NIVEL > 921)
{
VVA = 0;
}  
}  
                     
void UMIDADE (void)
{    
     
UMIDADE = ADC_read(1);
delay_ms (15);

if (UMIDADE >= 1003 || NIVEL <= 256)
{
PULVERIZA = 0;
}
    
else if (UMIDADE <= 870)
{
PULVERIZA = 1;
}
}

void TEMPERATURA (void)
{  
TEMPERATURA = ADC_read(2);
delay_ms (15);

if (TEMPERATURA >= 399)  
{
REFRIGERADOR = 1;
}
else if (TEMPERATURA <= 349) 
{
REFRIGERADOR = 0;
}
}     
     
void LUMINOSIDADE (void) 
{
LUMINOSIDADE = ADC_read(3);
delay_ms (15);
       
i = i ++;
if (i > 334)
{
i = 0;
}
else if (i > 167)
LAMPADA = 1;
}   
else
{
LAMPADA = 0;
}