class Counter {
	value = 0;
	constructor(n) {
		this.name = n;
	}

	get Name() {
		return this.name;
	}

	get Count() {
		return this.value;
	}
	Increment() {
		this.value++;
	}
	Reset() {
		this.value = 0;
	}
}

class Clock {
	seconds = new Counter('seconds');
	minutes = new Counter('minutes');
	hours = new Counter('hours');

	Reset() {
		this.seconds.Reset();
		this.minutes.Reset();
		this.hours.Reset();
	}

	get ReadTime() {
		return `${this.hours.Count}:${this.minutes.Count}:${this.seconds.Count}`;
	}

	Tick() {
		if (this.seconds.Count < 59) {
			this.seconds.Increment();
		} else {
			this.seconds.Reset();
			if (this.minutes.Count < 59) {
				this.minutes.Increment();
			} else {
				this.minutes.Reset();
				if (this.hours.Count == 23) {
					this.hours.Reset();
				} else {
					this.hours.Increment();
				}
			}
		}
	}
}

let clock = new Clock();

for (var i = 0; i < 60 * 60 * 24 + 61; i++) {
	clock.Tick();
	console.log(clock.ReadTime);
}
