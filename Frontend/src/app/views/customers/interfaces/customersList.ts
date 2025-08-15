export interface Customer {
  id: string;
  name: string;
  email: string;
  createdAt: Date;
}

export interface CustomerForm {
  name: string;
  email: string;
}
