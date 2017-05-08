export class Customer {
    constructor(
        public customerId: number,
        public firstName: string,
        public lastName: string,
        public gender: string,
        public phoneNumber: string,
        public emailAddress: string,
        public address1: string,
        public address2: string,
        public city: string,
        public state: string,
        public zip: number
    ) { }
}