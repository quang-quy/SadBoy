import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/dm-khoa-buong",
    method: "get",
    params,
  });
}
export function detail(id) {
  return request({
    url: `/dm-khoa-buong/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/dm-khoa-buong/${id}`,
    method: "put",
  });
}
export function detroy(id) {
  return request({
    url: `/dm-khoa-buong/${id}`,
    method: "delete",
  });
}

