import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/dm-benhtat-yhct",
    method: "get",
    params,
    cache: true,
  });
}
export function detail(id) {
  return request({
    url: `/dm-benhtat-yhct/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/dm-benhtat-yhct/${id}`,
    method: "put",
  });
}
export function detroy(id) {
  return request({
    url: `/dm-benhtat-yhct/${id}`,
    method: "delete",
  });
}

