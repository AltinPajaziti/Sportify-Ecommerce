export interface Register {
    name: string;
    surname: string;
    address: string;
    passwordHash: string;
    passwordSalt: string;
    roleid: number;
    roli: string | null;
    email: string;
    id: number;
    insertedby: string | null;
    lastModified: Date | null;
  }
  