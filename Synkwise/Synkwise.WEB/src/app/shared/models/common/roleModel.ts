/**
 * Created by coprita on 11/19/2017.
 */
export class RoleModel {
  constructor(id: number, name: string) {
    this.name = name;
    this.id = id;
  }

  name: string;
  id: number;
}
