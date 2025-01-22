import { http } from "@/utils/http";

/**
 * @description: 获取资产列表
 */
export function getPageList(params) {
  return http.request("get", "/asset/paged-list", { params });
}

export const submitData = (params: any) => {
  return http.request(params.id ? "put" : "post", `/asset/${params.id ?? ""}`, {
    data: params
  });
};

export const getSingle = (id: number) => {
  return http.request("get", `/asset/${id}`);
};

export const deleteData = (id: number) => {
  return http.request("delete", `/asset/${id}`);
};
