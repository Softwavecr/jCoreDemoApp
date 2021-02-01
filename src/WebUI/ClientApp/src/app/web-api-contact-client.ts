
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';
import { FileResponse, IContactItemsClient, SwaggerException } from './web-api-client';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface IContactItemsClient2 {
    getContactItems(): Observable<ContactItemDto[]>;
}

@Injectable({
    providedIn: 'root'
})
export class ContactItemsClient2 implements IContactItemsClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    getContactItems(): Observable<ContactItemDto[]> {
        let url_ = this.baseUrl + "/api/ContactItems";

        return this.http.request("get", url_).pipe(_observableMergeMap((response_ : any) => {
            return this.processgetContactItems(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processgetContactItems(<any>response_);
                } catch (e) {
                    return <Observable<ContactItemDto[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<ContactItemDto[]>><any>_observableThrow(response_);
        }));        
    }

    protected processgetContactItems(response: HttpResponseBase): Observable<ContactItemDto[]> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = ContactItemDto.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<ContactItemDto[]>(<any>null);
    }


    getContactItemsWithPagination(id: number | undefined, pageNumber: number | undefined, pageSize: number | undefined): Observable<PaginatedListOfContactItemDto> {
        let url_ = this.baseUrl + "/api/ContactItems?";
        if (id === null)
            throw new Error("The parameter 'id' cannot be null.");
        else if (id !== undefined)
            url_ += "Id=" + encodeURIComponent("" + id) + "&";
        if (pageNumber === null)
            throw new Error("The parameter 'pageNumber' cannot be null.");
        else if (pageNumber !== undefined)
            url_ += "PageNumber=" + encodeURIComponent("" + pageNumber) + "&";
        if (pageSize === null)
            throw new Error("The parameter 'pageSize' cannot be null.");
        else if (pageSize !== undefined)
            url_ += "PageSize=" + encodeURIComponent("" + pageSize) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetContactItemsWithPagination(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetContactItemsWithPagination(<any>response_);
                } catch (e) {
                    return <Observable<PaginatedListOfContactItemDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<PaginatedListOfContactItemDto>><any>_observableThrow(response_);
        }));
    }

    protected processGetContactItemsWithPagination(response: HttpResponseBase): Observable<PaginatedListOfContactItemDto> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = PaginatedListOfContactItemDto.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<PaginatedListOfContactItemDto>(<any>null);
    }

    create(command: CreateContactItemCommand): Observable<number> {
        let url_ = this.baseUrl + "/api/ContactItems";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCreate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCreate(<any>response_);
                } catch (e) {
                    return <Observable<number>><any>_observableThrow(e);
                }
            } else
                return <Observable<number>><any>_observableThrow(response_);
        }));
    }

    protected processCreate(response: HttpResponseBase): Observable<number> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 !== undefined ? resultData200 : <any>null;
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<number>(<any>null);
    }

    update(id: number, command: UpdateContactItemCommand): Observable<FileResponse> {
        let url_ = this.baseUrl + "/api/ContactItems/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("put", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUpdate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdate(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse>><any>_observableThrow(response_);
        }));
    }

    protected processUpdate(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse>(<any>null);
    }

    delete(id: number): Observable<FileResponse> {
        let url_ = this.baseUrl + "/api/ContactItems/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDelete(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDelete(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse>><any>_observableThrow(response_);
        }));
    }

    protected processDelete(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse>(<any>null);
    }

    updateItemDetails(id: number | undefined, command: UpdateContactItemDetailCommand): Observable<FileResponse> {
        let url_ = this.baseUrl + "/api/ContactItems/UpdateItemDetails?";
        if (id === null)
            throw new Error("The parameter 'id' cannot be null.");
        else if (id !== undefined)
            url_ += "id=" + encodeURIComponent("" + id) + "&";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("put", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUpdateItemDetails(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdateItemDetails(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse>><any>_observableThrow(response_);
        }));
    }

    protected processUpdateItemDetails(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse>(<any>null);
    }
}

export class PaginatedListOfContactItemDto implements IPaginatedListOfContactItemDto {
    items?: ContactItemDto[] | undefined;
    pageIndex?: number;
    totalPages?: number;
    totalCount?: number;
    hasPreviousPage?: boolean;
    hasNextPage?: boolean;

    constructor(data?: IPaginatedListOfContactItemDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["items"])) {
                this.items = [] as any;
                for (let item of _data["items"])
                    this.items!.push(ContactItemDto.fromJS(item));
            }
            this.pageIndex = _data["pageIndex"];
            this.totalPages = _data["totalPages"];
            this.totalCount = _data["totalCount"];
            this.hasPreviousPage = _data["hasPreviousPage"];
            this.hasNextPage = _data["hasNextPage"];
        }
    }

    static fromJS(data: any): PaginatedListOfContactItemDto {
        data = typeof data === 'object' ? data : {};
        let result = new PaginatedListOfContactItemDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        data["pageIndex"] = this.pageIndex;
        data["totalPages"] = this.totalPages;
        data["totalCount"] = this.totalCount;
        data["hasPreviousPage"] = this.hasPreviousPage;
        data["hasNextPage"] = this.hasNextPage;
        return data; 
    }
}

export interface IPaginatedListOfContactItemDto {
    items?: ContactItemDto[] | undefined;
    pageIndex?: number;
    totalPages?: number;
    totalCount?: number;
    hasPreviousPage?: boolean;
    hasNextPage?: boolean;
}

export class ContactItemDto implements IContactItemDto {
    id?: number;
    name?: string | undefined;
    company?: string | undefined;
    profileImage?: string | undefined;
    email?: string | undefined;
    birthDate?: string | undefined;
    phoneNumberWork?: string | undefined;
    phoneNumberPersonal?: string | undefined;
    address?: string | undefined;
    deleted?: boolean;
    priority?: number;

    constructor(data?: IContactItemDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.company = _data["company"];
            this.profileImage = _data["profileImage"];
            this.email = _data["email"];
            this.birthDate = _data["birthDate"];
            this.phoneNumberWork = _data["phoneNumberWork"];
            this.phoneNumberPersonal = _data["phoneNumberPersonal"];
            this.address = _data["address"];
            this.deleted = _data["deleted"];
            this.priority = _data["priority"];
        }
    }

    static fromJS(data: any): ContactItemDto {
        data = typeof data === 'object' ? data : {};
        let result = new ContactItemDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["company"] = this.company;
        data["profileImage"] = this.profileImage;
        data["email"] = this.email;
        data["birthDate"] = this.birthDate;
        data["phoneNumberWork"] = this.phoneNumberWork;
        data["phoneNumberPersonal"] = this.phoneNumberPersonal;
        data["address"] = this.address;
        data["deleted"] = this.deleted;
        data["priority"] = this.priority;
        return data; 
    }
}

export interface IContactItemDto {
    id?: number;
    name?: string | undefined;
    company?: string | undefined;
    profileImage?: string | undefined;
    email?: string | undefined;
    birthDate?: string | undefined;
    phoneNumberWork?: string | undefined;
    phoneNumberPersonal?: string | undefined;
    address?: string | undefined;
    deleted?: boolean;
    priority?: number;
}

export class CreateContactItemCommand implements ICreateContactItemCommand {
    id?: number;
    name?: string | undefined;
    company?: string | undefined;
    profileImage?: string | undefined;
    email?: string | undefined;
    birthDate?: string | undefined;
    phoneNumberWork?: string | undefined;
    phoneNumberPersonal?: string | undefined;
    address?: string | undefined;
    deleted?: boolean;
    priority?: number;

    constructor(data?: ICreateContactItemCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.company = _data["company"];
            this.profileImage = _data["profileImage"];
            this.email = _data["email"];
            this.birthDate = _data["birthDate"];
            this.phoneNumberWork = _data["phoneNumberWork"];
            this.phoneNumberPersonal = _data["phoneNumberPersonal"];
            this.address = _data["address"];
            this.deleted = _data["deleted"];
            this.priority = _data["priority"];
        }
    }

    static fromJS(data: any): CreateContactItemCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateContactItemCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["company"] = this.company;
        data["profileImage"] = this.profileImage;
        data["email"] = this.email;
        data["birthDate"] = this.birthDate;
        data["phoneNumberWork"] = this.phoneNumberWork;
        data["phoneNumberPersonal"] = this.phoneNumberPersonal;
        data["address"] = this.address;
        data["deleted"] = this.deleted;
        data["priority"] = this.priority;
        return data; 
    }
}

export interface ICreateContactItemCommand {
    id?: number;
    name?: string | undefined;
    company?: string | undefined;
    profileImage?: string | undefined;
    email?: string | undefined;
    birthDate?: string | undefined;
    phoneNumberWork?: string | undefined;
    phoneNumberPersonal?: string | undefined;
    address?: string | undefined;
    deleted?: boolean;
    priority?: number;
}

export class UpdateContactItemCommand implements IUpdateContactItemCommand {
    id?: number;
    name?: string | undefined;
    company?: string | undefined;
    profileImage?: string | undefined;
    email?: string | undefined;
    birthDate?: string | undefined;
    phoneNumberWork?: string | undefined;
    phoneNumberPersonal?: string | undefined;
    address?: string | undefined;
    deleted?: boolean;
    priority?: number;

    constructor(data?: IUpdateContactItemCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.company = _data["company"];
            this.profileImage = _data["profileImage"];
            this.email = _data["email"];
            this.birthDate = _data["birthDate"];
            this.phoneNumberWork = _data["phoneNumberWork"];
            this.phoneNumberPersonal = _data["phoneNumberPersonal"];
            this.address = _data["address"];
            this.deleted = _data["deleted"];
            this.priority = _data["priority"];
        }
    }

    static fromJS(data: any): UpdateContactItemCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateContactItemCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["company"] = this.company;
        data["profileImage"] = this.profileImage;
        data["email"] = this.email;
        data["birthDate"] = this.birthDate;
        data["phoneNumberWork"] = this.phoneNumberWork;
        data["phoneNumberPersonal"] = this.phoneNumberPersonal;
        data["address"] = this.address;
        data["deleted"] = this.deleted;
        data["priority"] = this.priority;
        return data; 
    }
}

export interface IUpdateContactItemCommand {
    id?: number;
    name?: string | undefined;
    company?: string | undefined;
    profileImage?: string | undefined;
    email?: string | undefined;
    birthDate?: string | undefined;
    phoneNumberWork?: string | undefined;
    phoneNumberPersonal?: string | undefined;
    address?: string | undefined;
    deleted?: boolean;
    priority?: number;
}

export class UpdateContactItemDetailCommand implements IUpdateContactItemDetailCommand {
    id?: number;
    name?: string | undefined;
    company?: string | undefined;
    profileImage?: string | undefined;
    email?: string | undefined;
    birthDate?: string | undefined;
    phoneNumberWork?: string | undefined;
    phoneNumberPersonal?: string | undefined;
    address?: string | undefined;
    deleted?: string | undefined;
    priority?: number;

    constructor(data?: IUpdateContactItemDetailCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.company = _data["company"];
            this.profileImage = _data["profileImage"];
            this.email = _data["email"];
            this.birthDate = _data["birthDate"];
            this.phoneNumberWork = _data["phoneNumberWork"];
            this.phoneNumberPersonal = _data["phoneNumberPersonal"];
            this.address = _data["address"];
            this.deleted = _data["deleted"];
            this.priority = _data["priority"];
        }
    }

    static fromJS(data: any): UpdateContactItemDetailCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateContactItemDetailCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["company"] = this.company;
        data["profileImage"] = this.profileImage;
        data["email"] = this.email;
        data["birthDate"] = this.birthDate;
        data["phoneNumberWork"] = this.phoneNumberWork;
        data["phoneNumberPersonal"] = this.phoneNumberPersonal;
        data["address"] = this.address;
        data["deleted"] = this.deleted;
        data["priority"] = this.priority;
        return data; 
    }
}

export interface IUpdateContactItemDetailCommand {
    id?: number;
    name?: string | undefined;
    company?: string | undefined;
    profileImage?: string | undefined;
    email?: string | undefined;
    birthDate?: string | undefined;
    phoneNumberWork?: string | undefined;
    phoneNumberPersonal?: string | undefined;
    address?: string | undefined;
    deleted?: string | undefined;
    priority?: number;
}


function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}