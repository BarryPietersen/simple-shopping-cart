import { LineItem } from "./line-item";

export class OrderSummary {
  total: number;
  shipping: number;
  grandTotal: number;
  lineItems: LineItem[];
}
