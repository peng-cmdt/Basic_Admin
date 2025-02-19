import { http } from "@/utils/http";

/**
 * @description: 获取资产列表
 */
export function getPageList(params) {
  return http.request("get", "/device-type/paged-list", { params });
}

export const submitData = (params: any) => {
  debugger;
  return http.request(
    params.deviceTypeIdInt ? "put" : "post",
    `/device-type/${params.deviceTypeIdInt ?? ""}`,
    {
      data: params
    }
  );
};

export const getDicSingle = (id: number) => {
  return http.request("get", `/dict-data/${id}`);
};

export const getSingle = (id: number) => {
  return http.request("get", `/device-type/${id}`);
};

export const deleteData = (id: number) => {
  return http.request("delete", `/device-type/${id}`);
};
