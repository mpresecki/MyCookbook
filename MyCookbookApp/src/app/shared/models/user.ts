export class User {
    id: number;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    token?: string;
}

export class UserRegistration {
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    address: string;
}

export class UserUpdate {
    id: number;
    email: string;
    firstName: string;
    lastName: string;
    address: string;
}
