Definição Pattern Oberver:
	Definir uma dependência um-para-muitos entre objetos para que quando um objeto muda de estado, todos 
	os seus dependentes são notificados e atualizados automaticamente.


Participantes do Pattern
    As classes e / ou objetos que participam deste padrão são:

	Subject (Stock):
		- Conhece seus observadores. Qualquer número de objetos Observer pode observar um assunto
		- Fornece uma interface para anexar e des-anexar objetos Observer.
 
	ConcreteSubject (IBM):
		- Armazena o estado de interesse para ConcreteObserver
		- Envia uma notificação para seus observadores quando seu estado muda

	Observer (IInvestor):
		- Define uma interface de atualização para objetos que devem ser notificados de mudanças em um assunto.

	ConcreteObserver (Investor):
		- Mantém uma referência a um objeto ConcreteSubject
		- Armazena o estado que deve ficar consistente com a do sujeito
		- Implementa a interface Observer atualizando para manter seu estado consistente com os "suject's"


Exemplos

Structural: // Observer pattern -- Structural example
	Este código demonstra o padrão Observer em que os objetos registrados são notificados de e atualizado com uma mudança de estado.


RealWorld:	// Observer pattern -- Real World example
	Este demonstra o padrão Observer em que os investidores(investor) estão registrados notificado sempre que um estoque do valor mudanças.
