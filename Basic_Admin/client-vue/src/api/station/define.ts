import { http } from "@/utils/http";

/**
 * @description: 获取设备列表
 */
export function getPageList(params) {
  return http.request("get", "/station/paged-list", { params });
}

export const submitData = (params: any) => {
  return http.request(
    params.id ? "put" : "post",
    `/station/${params.id ?? ""}`,
    {
      data: params
    }
  );
};

export const getSingle = (id: number) => {
  return http.request("get", `/station/${id}`);
};

export const deleteData = (id: number) => {
  return http.request("delete", `/station/${id}`);
};
